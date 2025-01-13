namespace Sharpliner.Extensions.JFrog.Builders;

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

public class JFrogGenericArtifactsDownloadTaskBuilder(string connection)
{
    public JFrogGenericArtifactsDownloadTask TaskConfiguration(string fileSpec) => new(connection)
    {
        SpecSource = SpecSources.TaskConfiguration,
        FileSpec = fileSpec
    };

    public JFrogGenericArtifactsDownloadTask File(string file) => new(connection)
    {
        SpecSource = SpecSources.File,
        File = file
    };
}

public class JFrogGenericArtifactsUploadTaskBuilder
{
    private readonly string _connection;

    internal JFrogGenericArtifactsUploadTaskBuilder(string connection)
    {
        _connection = connection;
    }

    public JFrogGenericArtifactsUploadTask TaskConfiguration(string fileSpec) => new(_connection)
    {
        Connection = _connection,
        SpecSource = SpecSources.TaskConfiguration,
        FileSpec = fileSpec
    };

    public JFrogGenericArtifactsUploadTask File(string file) => new(_connection)
    {
        Connection = _connection,
        SpecSource = SpecSources.File,
        File = file
    };
}