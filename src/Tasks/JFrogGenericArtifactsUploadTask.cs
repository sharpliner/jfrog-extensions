namespace Sharpliner.Extensions.JFrog;

public record JFrogGenericArtifactsUploadTask : JFrogGenericArtifactsTask
{
    public JFrogGenericArtifactsUploadTask(string connection) : base("Upload", connection)
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

    /// <summary>
    /// Select if you'd like that Symlink file representation will contain the symbolic link and checksum properties.
    /// </summary>
    [YamlIgnore]
    public bool? PreserveSymlinks
    {
        get => GetBool("preserveSymlinks", false);
        init => SetProperty("preserveSymlinks", value);
    }

    /// <summary>
    /// Select if you'd like to Specify the distribution/component/architecture of the package.
    /// Used for Debian packages only.
    /// </summary>
    [YamlIgnore]
    public bool? SetDebianProps
    {
        get => GetBool("setDebianProps", false);
        init => SetProperty("setDebianProps", value);
    }


    [YamlIgnore]
    public string? DebDistribution
    {
        get => GetString("debDistribution");
        init
        {
            if (SetDebianProps == false)
            {
                throw new InvalidOperationException("DebDistribution can only be set when SetDebianProps is true");
            }
            SetProperty("debDistribution", value);
        }
    }

    [YamlIgnore]
    public string? DebComponent
    {
        get => GetString("debComponent");
        init
        {
            if (SetDebianProps == false)
            {
                throw new InvalidOperationException("DebComponent can only be set when SetDebianProps is true");
            }
            SetProperty("debComponent", value);
        }
    }

    [YamlIgnore]
    public string? DebArchitecture
    {
        get => GetString("debArchitecture");
        init
        {
            if (SetDebianProps == false)
            {
                throw new InvalidOperationException("DebArchitecture can only be set when SetDebianProps is true");
            }
            SetProperty("debArchitecture", value);
        }
    }

    /// <summary>
    /// If you'd like to sync artifacts after the upload, set a specific path in Artifactory. Leave empty otherwise.
    /// If set, after the upload completes, this path will include only the artifacts uploaded during this upload operation. The other files under this path will be deleted.
    /// </summary>
    [YamlIgnore]
    public string? SyncDeletesPathRemote
    {
        get => GetString("syncDeletesPathRemote");
        init => SetProperty("syncDeletesPathRemote", value);
    }
}
