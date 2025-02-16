namespace Sharpliner.Extensions.JFrogTasks.Builders;

public class JFrogGenericArtifactsTaskBuilder
{
    internal JFrogGenericArtifactsTaskBuilder()
    {
    }

    /// <summary>
    /// Creates the <c>Upload</c> command version of the JFrogGenericArtifacts task.
    /// </summary>
    public JFrogGenericArtifactsUploadTaskBuilder Upload(string connection) => new(connection);

    public JFrogGenericArtifactsDownloadTaskBuilder Download(string connection) => new(connection);
}