#pragma warning disable CA1822
namespace Sharpliner.Extensions.JFrogTasks.Builders;

public class JFrogGenericArtifactsTaskBuilder
{
    internal JFrogGenericArtifactsTaskBuilder()
    {
    }

    /// <summary>
    /// The <c>Upload</c> command
    /// </summary>
    /// <param name="connection">Artifactory service connection</param>
    public JFrogGenericArtifactsUploadTaskBuilder Upload(string connection) => new(connection);

    /// <summary>
    /// The <c>Download</c> command
    /// </summary>
    /// <param name="connection">Artifactory service connection</param>
    public JFrogGenericArtifactsDownloadTaskBuilder Download(string connection) => new(connection);
}