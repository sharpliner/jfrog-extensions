namespace Sharpliner.Extensions.JFrogTasks;

/// <summary>
/// Publishes build information to JFrog Artifactory.
/// </summary>
/// <remarks>
/// https://github.com/jfrog/jfrog-azure-devops-extension/blob/v2/tasks/JFrogPublishBuildInfo/task.json
/// </remarks>
public record JFrogPublishBuildInfoTask : AzureDevOpsTask
{
    public JFrogPublishBuildInfoTask(string connection) : base("JFrogPublishBuildInfo@1")
    {
        Connection = connection;
    }

    /// <summary>
    /// Artifactory service to be used by this task.
    /// </summary>
    [YamlIgnore]
    public string Connection
    {
        get => GetString("artifactoryConnection")!;
        init => SetProperty("artifactoryConnection", value);
    }

    /// <summary>
    /// Build name.
    /// To use the default build name of the pipeline, set the field to '$(Build.DefinitionName)'.
    /// </summary>
    [YamlIgnore]
    public string? BuildName
    {
        get => GetString("buildName", "$(Build.DefinitionName)")!;
        init
        {
            SetProperty("buildName", value);
        }
    }

    /// <summary>
    /// Build number.
    /// To use the default build number of the pipeline, set the field to '$(Build.BuildNumber)'.
    /// </summary>
    [YamlIgnore]
    public string? BuildNumber
    {
        get => GetString("buildNumber", "$(Build.BuildNumber)")!;
        init
        {
            SetProperty("buildNumber", value);
        }
    }

    /// <summary>
    /// JFrog Project key.
    /// </summary>
    [YamlIgnore]
    public string? ProjectKey
    {
        get => GetString("projectKey");
        init
        {
            SetProperty("projectKey", value);
        }
    }

    /// <summary>
    /// Exclude environment variables
    /// </summary>
    /// <remarks>
    /// List of case-insensitive patterns in the form of value1;value2;.... Environment variables match those patterns will be excluded from the published build info.
    /// </remarks>
    [YamlIgnore]
    public string? ExcludeEnvVars
    {
        get => GetString("excludeEnvVars", "*password*;*psw*;*secret*;*key*;*token*;*auth*;");
        init
        {
            SetProperty("excludeEnvVars", value);
        }
    }
}