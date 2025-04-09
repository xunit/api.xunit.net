using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bullseye.Internal;
using Xunit.BuildTools.Models;

[Target(BuildTarget.Metadata)]
public static partial class Metadata
{
	static readonly Regex childRegex = GetChildRegex();
	static readonly Regex inlineHrefRegex = GetInlineHrefRegex();
	static readonly Regex overloadRegex = GetOverloadRegex();
	static readonly Regex parentRegex = GetParentRegex();
	static readonly Regex uidRegex = GetUidRegex();

	public static async Task OnExecute(BuildContext context)
	{
		context.BuildStep("Processing metadata");

		foreach (var outerFolder in Directory.GetDirectories(Path.Combine(context.BaseFolder, "metadata")))
			foreach (var innerFolder in Directory.GetDirectories(outerFolder))
			{
				context.WriteLineColor(ConsoleColor.DarkGray, "PROCESSING: " + innerFolder);

				var prefix = $"{Path.GetFileName(outerFolder)}.{Path.GetFileName(innerFolder)}:";
				await ProcessFolder(context, innerFolder, prefix);
			}

		Console.WriteLine();
	}

	static async Task ProcessFolder(
		BuildContext context,
		string folder,
		string prefix)
	{
		var processedFileName = Path.Combine(folder, ".processed");
		if (File.Exists(processedFileName))
			return;

		var manifestFileName = Path.Combine(folder, ".manifest");
		if (!File.Exists(manifestFileName))
			throw new InvalidOperationException("Could not find manifest file: " + manifestFileName);

		var newManifest = new Dictionary<string, string>();

		using (var manifestStream = File.Open(manifestFileName, FileMode.Open, FileAccess.Read))
		{
			var manifest =
				await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(manifestStream)
					?? throw new InvalidOperationException("Could not deserialize manifest file: " + manifestFileName);

			foreach (var kvp in manifest)
				if (kvp.Key.StartsWith(prefix))
					newManifest[kvp.Key] = kvp.Value;
				else
					newManifest[prefix + kvp.Key] = kvp.Value;
		}

		// context.WriteLineColor(ConsoleColor.DarkGray, "  .manifest");

		using (var manifestStream = File.Open(manifestFileName, FileMode.Create))
		using (var textWriter = new StreamWriter(manifestStream))
		{
			await textWriter.WriteLineAsync("{");

			var first = true;
			foreach (var kvp in newManifest)
			{
				if (first)
					first = false;
				else
					await textWriter.WriteLineAsync(",");

				await textWriter.WriteAsync($"  \"{kvp.Key}\": \"{kvp.Value}\"");
			}

			await textWriter.WriteLineAsync();
			await textWriter.WriteLineAsync("}");
		}

		foreach (var ymlFileName in Directory.GetFiles(folder, "*.yml"))
		{
			// context.WriteLineColor(ConsoleColor.DarkGray, "  " + Path.GetFileName(ymlFileName));

			var yml = await File.ReadAllLinesAsync(ymlFileName);

			for (var idx = 0; idx < yml.Length; ++idx)
			{
				// These are whole-line replacements, so we only want the first one that matches
				var replacement =
					findAndReplace(uidRegex, yml[idx], m => $"{yml[idx][..m.Index]}uid: {prefix}Xunit{m.Groups[1].Value}") ??
					findAndReplace(parentRegex, yml[idx], m => $"{yml[idx][..m.Index]}parent: {prefix}Xunit{m.Groups[1].Value}") ??
					findAndReplace(overloadRegex, yml[idx], m => $"{yml[idx][..m.Index]}overload: {prefix}Xunit{m.Groups[1].Value}") ??
					findAndReplace(childRegex, yml[idx], m => $"{yml[idx][..m.Index]}- {prefix}Xunit{m.Groups[1].Value}");

				if (replacement is not null)
					yml[idx] = replacement;
				else
				{
					// These are inline replacements, so we want to do them all
					while (true)
					{
						var hrefMatch = inlineHrefRegex.Match(yml[idx]);
						if (!hrefMatch.Success)
							break;

						yml[idx] = $"{yml[idx][..hrefMatch.Index]}href=\"{prefix}Xunit{hrefMatch.Groups[1].Value}\"{yml[idx][(hrefMatch.Index + hrefMatch.Length)..]}";
					}
				}
			}

			await File.WriteAllLinesAsync(ymlFileName, yml);
		}

		await File.WriteAllTextAsync(processedFileName, string.Empty);

		static string? findAndReplace(
			Regex regex,
			string value,
			Func<Match, string> converter)
		{
			var match = regex.Match(value);
			if (!match.Success)
				return null;

			return converter(match);
		}
	}

	[GeneratedRegex("- Xunit(.*)$")]
	private static partial Regex GetChildRegex();

	[GeneratedRegex("href=\\\"Xunit(.*?)\\\"")]
	private static partial Regex GetInlineHrefRegex();

	[GeneratedRegex("overload: Xunit(.*)$")]
	private static partial Regex GetOverloadRegex();

	[GeneratedRegex("parent: Xunit(.*)$")]
	private static partial Regex GetParentRegex();

	[GeneratedRegex("uid: Xunit(.*)$")]
	private static partial Regex GetUidRegex();
}
