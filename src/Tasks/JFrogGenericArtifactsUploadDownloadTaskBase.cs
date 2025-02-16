namespace Sharpliner.Extensions.JFrogTasks;

public abstract record JFrogGenericArtifactsUploadDownloadTaskBase : JFrogGenericArtifactsTask
{
    protected JFrogGenericArtifactsUploadDownloadTaskBase(string command, string connection) : base(command, connection)
    {
    }

    /// <summary>
    /// Collect build info and store it locally.
    /// The build info can be later published to Artifactory using the \"JFrog Publish Build Info\" task.
    /// </summary>
    [YamlIgnore]
    public bool? CollectBuildInfo
    {
        get => GetBool("collectBuildInfo", false);
        init => SetProperty("collectBuildInfo", value);
    }

    /// <summary>
    /// Build name.
    /// To use the default build name of the pipeline, set the field to '$(Build.DefinitionName)'.
    /// The collected build-info should be published to Artifactory using the 'JFrog Publish Build Info' task.
    /// </summary>
    [YamlIgnore]
    public string? BuildName
    {
        get => GetString("buildName", "$(Build.DefinitionName)")!;
        init
        {
            if (CollectBuildInfo == false)
            {
                throw new InvalidOperationException("BuildName can only be set when CollectBuildInfo is true");
            }

            SetProperty("buildName", value);
        }
    }

    /// <summary>
    /// Build number.
    /// To use the default build number of the pipeline, set the field to '$(Build.BuildNumber)'.
    /// The collected build-info should be published to Artifactory using the 'JFrog Publish Build Info' task.
    /// </summary>
    [YamlIgnore]
    public string? BuildNumber
    {
        get => GetString("buildNumber", "$(Build.BuildNumber)")!;
        init
        {
            if (CollectBuildInfo == false)
            {
                throw new InvalidOperationException("BuildNumber can only be set when CollectBuildInfo is true");
            }
            SetProperty("buildNumber", value);
        }
    }

    /// <summary>
    /// Module name.
    /// Optional module name for the build-info.
    /// The collected build-info should be published to Artifactory using the 'JFrog Publish Build Info' task.
    /// </summary>
    [YamlIgnore]
    public string? Module
    {
        get => GetString("module");
        init
        {
            if (CollectBuildInfo == false)
            {
                throw new InvalidOperationException("Module can only be set when CollectBuildInfo is true");
            }
            SetProperty("module", value);
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
            if (CollectBuildInfo == false)
            {
                throw new InvalidOperationException("ProjectKey can only be set when CollectBuildInfo is true");
            }
            SetProperty("projectKey", value);
        }
    }

    /// <summary>
    /// Select to include environment variables in the published build info.
    /// </summary>
    [YamlIgnore]
    public bool? IncludeEnvVars
    {
        get => GetBool("includeEnvVars", false);
        init
        {
            if (CollectBuildInfo == false)
            {
                throw new InvalidOperationException("IncludeEnvVars can only be set when CollectBuildInfo is true");
            }
            SetProperty("includeEnvVars", value);
        }
    }

    /// <summary>
    /// Select if you'd like the task to only indicates which artifacts would have been affected.
    /// If not, the command is fully executed as specified
    /// </summary>
    [YamlIgnore]
    public bool? DryRun
    {
        get => GetBool("dryRun", false);
        init => SetProperty("dryRun", value);
    }
}