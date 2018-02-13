var project = "src/ProjectParser/ProjectParser.csproj";

var npi = EnvironmentVariable("npi");

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
        DotNetCorePack(project);
    });

Task("Publish-Nuget")
    .IsDependentOn("Create-Nuget-Package")
    .Does(() => {
        var nupkg = new DirectoryInfo("src/ProjectParser/bin/Release").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
});

var target = Argument("target", "default");
RunTarget(target);