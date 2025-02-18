#pragma warning disable CA1822
namespace Sharpliner.Extensions.JFrogTasks.Builders;

public class JFrogTaskBuilder
{
    /// <summary>
    /// Creates a JFrogGenericArtifacts task
    /// </summary>
    public JFrogGenericArtifactsTaskBuilder GenericArtifacts => new();

    /// <summary>
    /// Creates a JFrogPublishBuildInfo task
    /// </summary>
    /// <param name="connection">Artifactory service connection</param>
    public JFrogPublishBuildInfoTask PublishBuildInfo(string connection) => new(connection);
}