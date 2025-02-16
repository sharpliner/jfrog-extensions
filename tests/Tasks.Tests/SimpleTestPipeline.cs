using Sharpliner.AzureDevOps;

namespace Sharpliner.Extensions.JFrogTasks.Tests;

internal abstract class SimpleTestPipeline : SingleStagePipelineDefinition
{
    public override string TargetFile => "azure-pipelines.yml";

    public override TargetPathType TargetPathType => TargetPathType.RelativeToGitRoot;
}