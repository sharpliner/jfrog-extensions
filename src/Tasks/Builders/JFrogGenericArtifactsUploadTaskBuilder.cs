namespace Sharpliner.Extensions.JFrogTasks.Builders;

/// <summary>
/// Builder for JFrog Generic Artifacts Upload task.
/// </summary>
public class JFrogGenericArtifactsUploadTaskBuilder
{
    private readonly string _connection;

    internal JFrogGenericArtifactsUploadTaskBuilder(string connection)
    {
        _connection = connection;
    }

    /// <summary>
    /// Use file spec from task configuration
    /// </summary>
    /// <remarks>
    /// See <see href="https://docs.jfrog-applications.jfrog.io/jfrog-applications/jfrog-cli/binaries-management-with-jfrog-artifactory/using-file-specs#examples">File Spec documentation</see>
    /// </remarks>
    /// <param name="fileSpec"></param>
    /// <returns></returns>
    public JFrogGenericArtifactsUploadTask TaskConfiguration(string fileSpec) => new(_connection)
    {
        Connection = _connection,
        SpecSource = SpecSources.TaskConfiguration,
        FileSpec = fileSpec
    };

    /// <summary>
    /// Use file spec from a local file
    /// </summary>
    public JFrogGenericArtifactsUploadTask File(string file) => new(_connection)
    {
        Connection = _connection,
        SpecSource = SpecSources.File,
        File = file
    };
}