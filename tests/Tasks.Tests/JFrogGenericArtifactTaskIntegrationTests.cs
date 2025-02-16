using Sharpliner.AzureDevOps;
using static Sharpliner.Extensions.JFrogTasks.Builders.JFrogTasks;

namespace Sharpliner.Extensions.JFrogTasks.Tests;

class PullRequestPipeline : SingleStagePipelineDefinition
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
                Steps =
                [
                    JFrog.GenericArtifacts.Download("Artifactory")
                        .TaskConfiguration("filespec")
                        ,
                ]
            }
        ],
    };
}