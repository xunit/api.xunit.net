#!/usr/bin/env pwsh
#Requires -Version 5.1

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function GuardBin {
	param (
		[string]$binary,
		[string]$message
	)

	if ($null -eq (Get-Command $binary -ErrorAction Ignore)) {
		throw "Could not find '$binary'; $message"
	}
}

GuardBin git "please install the Git CLI from https://git-scm.com/"
GuardBin dotnet "please install the .NET SDK from https://dot.net/"
GuardBin npm "please install Node and npm from (https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)"
GuardBin docker "please install Docker from (https://docs.docker.com/engine/install/)"

$version = [Version]$([regex]::matches((&dotnet --version), '^(\d+\.)?(\d+\.)?(\*|\d+)').value)
if ($version.Major -lt 9) {
	throw ".NET SDK version ($version) is too low; please install version 9.0 from https://dot.net/"
}

& git submodule status | ForEach-Object {
	if ($_[0] -eq '-') {
		$pieces = $_.Split(' ')
		& git submodule update --init "$($pieces[1])"
		Write-Host ""
	}
}

Push-Location (Split-Path $MyInvocation.MyCommand.Definition)

try {
	& dotnet run --project tools/builder --no-launch-profile -- $args
}
finally {
	Pop-Location
}
