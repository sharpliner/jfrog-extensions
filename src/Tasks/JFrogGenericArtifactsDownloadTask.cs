namespace Sharpliner.Extensions.JFrog;

public record JFrogGenericArtifactsDownloadTask : JFrogGenericArtifactsUploadDownloadTaskBase
{
    public JFrogGenericArtifactsDownloadTask(string connection) : base("Download", connection)
    {
    }
}