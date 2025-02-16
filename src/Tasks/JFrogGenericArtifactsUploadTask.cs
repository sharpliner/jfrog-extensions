namespace Sharpliner.Extensions.JFrogTasks;

public record JFrogGenericArtifactsUploadTask : JFrogGenericArtifactsUploadDownloadTaskBase
{
    public JFrogGenericArtifactsUploadTask(string connection) : base("Upload", connection)
    {
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
