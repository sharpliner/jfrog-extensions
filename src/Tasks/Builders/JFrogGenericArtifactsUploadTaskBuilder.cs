namespace Sharpliner.Extensions.JFrogTasks.Builders;

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