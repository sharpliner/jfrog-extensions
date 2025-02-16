using Sharpliner.AzureDevOps;
using Sharpliner.Extensions.JFrogTasks.Builders;

namespace Sharpliner.Extensions.JFrogTasks.Tests;

public class JFrogPublishBuildInfoTaskTests
{
    private readonly JFrogTaskBuilder _builder = new();
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
    public Task PublishBuildInfo()
    {
        var task = _builder.PublishBuildInfo("Artifactory")
            with
            {
                BuildName = "ThisBuild", 
                BuildNumber = "1.0.0", 
                ProjectKey = "projectKey",
                ExcludeEnvVars = "*password*;*psw*;*secret*;*key*;*token*;*auth*;*shush*"
        };

        return Verify(GetYaml(task));
    }

    private static string GetYaml(Step task) => new JFrog_Pipeline(task).Serialize();
}