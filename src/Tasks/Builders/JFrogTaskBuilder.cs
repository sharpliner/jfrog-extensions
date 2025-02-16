namespace Sharpliner.Extensions.JFrogTasks.Builders;

public class JFrogTaskBuilder
{
    public JFrogGenericArtifactsTaskBuilder GenericArtifacts => new();
    public JFrogPublishBuildInfoTask PublishBuildInfo(string connection) => new(connection);
}