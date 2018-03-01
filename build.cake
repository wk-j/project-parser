#addin nuget:?package=ProjectParser&version=0.3.0
using ProjectParser;

var project = "src/ProjectParser/ProjectParser.csproj";
var npi = EnvironmentVariable("npi");

Task("Version").Does(() => {
    var info = Parser.Parse(project);
    Information($"Versin = {info.Version}");
});

Action<string,string,string> ps = (cmd, args, dir) => {
    StartProcess(cmd, new ProcessSettings {
        Arguments = args,
        WorkingDirectory = dir
    });
};

Task("Restore").Does(() => {
    DotNetCoreRestore(project);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => {
        DotNetCoreBuild(project, new DotNetCoreBuildSettings { 
            Configuration = "Release"
        });
    });

Task("Create-Nuget-Package")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCorePack(project, new DotNetCorePackSettings { 
            Configuration = "Release",
            OutputDirectory = "publish"
        });
    });

Task("Publish-Nuget")
    .IsDependentOn("Create-Nuget-Package")
    .Does(() => {
        var nupkg = new DirectoryInfo("publish").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
});

var target = Argument("target", "default");
RunTarget(target);