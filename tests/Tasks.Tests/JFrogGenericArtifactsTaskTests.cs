using Sharpliner.AzureDevOps;
using Sharpliner.Extensions.JFrog.Builders;

namespace Sharpliner.Extensions.JFrog.Tests;

public class JfrogGenericArtifactTaskTests
{
    private readonly JFrogGenericArtifactsTaskBuilder _builder = new();

    private class JFrog_Pipeline(Step step) : SimpleTestPipeline
    {
        public override SingleStagePipeline Pipeline => new()
        {
            Jobs =
            {
                new Job("job")
                {
                    Steps = { step }
                }
            }
        };
    }

    [Fact]
    public Task Upload_Command()
    {
        var task = _builder.Upload("serviceConnection")
            .TaskConfiguration("fileSpec");

        return Verify(GetYaml(task));
    }

    [Fact]
    public Task Download_Command() {
        var task = _builder.Download("serviceConnection")
            .TaskConfiguration("fileSpec");
        return Verify(GetYaml(task));
    }

    [Fact]
    public Task Upload_Full_Command()
    {
        var task = _builder.Upload("serviceConnection")
            .TaskConfiguration("""
                               {
                                       "files": [
                                         {
                                           "pattern": "libs-generic-local/*.zip",
                                           "target": "dependencies/files/"
                                         }
                                       ]
                                     }
                               """) with
        {
            CollectBuildInfo = true,
            BuildName = "ThisBuild",
            BuildNumber = "1.0.0",
            ReplaceSpecVars = true,
            SpecVars = "key1=value1;key2=value2",
            ProjectKey = "projectKey",
            IncludeEnvVars = true,
            FailNoOp = true,
            WorkingDirectory = Path.GetTempPath(),
            SetDebianProps = true,
            DebArchitecture = "amd64",
            DebComponent = "main",
            DebDistribution = "focal",
            PreserveSymlinks = true,
            SyncDeletesPathRemote = "libs-generic-local/",
            
        };

        return Verify(GetYaml(task));
    }

    [Fact]
    public Task Download_Full_Command() {
        var task = _builder.Download("serviceConnection")
            .TaskConfiguration("""
                               {
                                       "files": [
                                         {
                                           "pattern": "libs-generic-local/*.zip",
                                           "target": "dependencies/files/"
                                         }
                                       ]
                                     }
                               """) with
        {
            CollectBuildInfo = true,
            BuildName = "ThisBuild",
            BuildNumber = "1.0.0",
            ReplaceSpecVars = true,
            SpecVars = "key1=value1;key2=value2",
            ProjectKey = "projectKey",
            Module = "a module",
            IncludeEnvVars = true,
            FailNoOp = true,
            WorkingDirectory = Path.GetTempPath(),
            InsecureTls = true,
            Threads = 5,
            Retries = 3,
            DryRun = true,
            SplitCount = 4,
            MinSplit = 2048,
            ValidateSymlinks = true,
            SyncDeletesPathLocal = "libs-generic-local/",

        };
        return Verify(GetYaml(task));
    }

    [Fact]
    public Task Upload_File_Command()
    {
        var task = _builder.Upload("serviceConnection")
            .File("file");
        return Verify(GetYaml(task));
    }

    private static string GetYaml(Step task) => new JFrog_Pipeline(task).Serialize();
}

internal abstract class SimpleTestPipeline : SingleStagePipelineDefinition
{
    public override string TargetFile => "azure-pipelines.yml";

    public override TargetPathType TargetPathType => TargetPathType.RelativeToGitRoot;
}
