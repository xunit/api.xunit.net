using System.IO;
using System.Threading.Tasks;
using Xunit.BuildTools.Models;

namespace Xunit.BuildTools.Targets;

[Target(BuildTarget.Serve)]
public static class Serve
{
	public static async Task OnExecute(BuildContext context)
	{
		context.BuildStep("Running web server");

		var sitePath = Path.Combine(context.BaseFolder, "_site");

		if (!Directory.Exists(sitePath))
			Directory.CreateDirectory(sitePath);

		await context.Exec("docker", $"run --rm --name api.xunit.net -p 4000:80 -v {sitePath}:/usr/share/nginx/html:ro nginx");
	}
}
