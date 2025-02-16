using Sharpliner.AzureDevOps;
using static Sharpliner.Extensions.JFrogTasks.Builders.JFrogTasks;

namespace Sharpliner.Extensions.JFrogTasks.Tests;

public class PullRequestPipeline : SingleStagePipelineDefinition
{
    // Say where to publish the YAML to
    public override string TargetFile => "eng/pr.yml";
    public override TargetPathType TargetPathType => TargetPathType.RelativeToGitRoot;

    public override SingleStagePipeline Pipeline => new()
    {
        Pr = new PrTrigger("main"),

        Jobs =
        [
            new Job("Build")
            {
                Pool = new HostedPool("Azure Pipelines", "windows-latest"),
                // begin-snippet: JFrogSteps
                Steps =
                [
                    JFrog.GenericArtifacts.Download("Artifactory")
                        .TaskConfiguration("""
                        {
                            "files": [
                                {
                                    "pattern": "libs-generic-local/*.zip",
                                    "target": "dependencies/files/"
                                }
                            ]
                        }
                        """),

                    JFrog.GenericArtifacts.Upload("Artifactory")
                            .TaskConfiguration("""

                            """) with
                            {
                                CollectBuildInfo = true,
                                BuildName = "MyBuildName",
                                BuildNumber = "1.0.0",
                                FailNoOp = true,
                            },

                    JFrog.PublishBuildInfo("Artifactory") with
                    {
                        BuildName = "MyBuildName",
                        BuildNumber = "1.0.0",
                        ProjectKey = "MyProject",
                        ExcludeEnvVars = "*password*;*secret*"

                    }
                ]
                // end-snippet
            }
        ],
    };
}