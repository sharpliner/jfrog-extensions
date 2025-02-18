namespace Sharpliner.Extensions.JFrogTasks.Builders;

public class JFrogGenericArtifactsDownloadTaskBuilder(string connection)
{
    /// <summary>
    /// Use file spec from task configuration
    /// </summary>
    /// <param name="fileSpec">The file spec</param>
    /// <remarks>
    /// See <see href="https://docs.jfrog-applications.jfrog.io/jfrog-applications/jfrog-cli/binaries-management-with-jfrog-artifactory/using-file-specs#examples">File Spec documentation</see>
    /// </remarks>
    public JFrogGenericArtifactsDownloadTask TaskConfiguration(string fileSpec) => new(connection)
    {
        SpecSource = SpecSources.TaskConfiguration,
        FileSpec = fileSpec
    };

    /// <summary>
    /// Use file spec from a local file
    /// </summary>
    /// <param name="file">Path to text file that contains file specs</param>
    public JFrogGenericArtifactsDownloadTask File(string file) => new(connection)
    {
        SpecSource = SpecSources.File,
        File = file
    };
}