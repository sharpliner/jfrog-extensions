namespace Sharpliner.Extensions.JFrogTasks.Builders;

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