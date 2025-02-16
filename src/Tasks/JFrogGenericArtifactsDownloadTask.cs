namespace Sharpliner.Extensions.JFrog;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// Based on <see href="https://www.jfrog.com/confluence/display/JFROG/Artifactory+Generic+Download">JFrog Documentation</see>.
/// </remarks>
public record JFrogGenericArtifactsDownloadTask : JFrogGenericArtifactsUploadDownloadTaskBase
{
    public JFrogGenericArtifactsDownloadTask(string connection) : base("Download", connection)
    {
    }

    private static readonly int[] ValidSplitCounts = [0, 1, 2,3,4,5,6,7,8,9,10,12,14,16,18,20,25,30,35,40,45,50,60,70,80,90,100
    ];

    /// <summary>
    /// # of splits
    /// </summary>
    /// <remarks>
    /// The number of segments into which each file should be split for download (provided the artifact is over the "min split" in size).
    /// To download each file in a single thread, set to 0.
    /// </remarks>
    [YamlIgnore]
    public int? SplitCount
    {
        get => GetInt("splitCount", 3);
        init
        {
            if (value.HasValue && !ValidSplitCounts.Contains(value.Value))
            {
                throw new ArgumentOutOfRangeException(nameof(SplitCount), value, $"Invalid split count. Valid values are: {string.Join(", ", ValidSplitCounts)}");
            }
        
            SetProperty("splitCount", value);
        }
    }

    /// <summary>
    /// The minimum size in KB for splitting files
    /// </summary>
    /// <remarks>
    /// Files larger than the specified number will be split into equally sized \"# of splits\" segments.\nAny files smaller than the specified number will be downloaded in a single thread. If set to -1, files are not split.\nThe default value is 5120
    /// </remarks>
    [YamlIgnore]
    public int? MinSplit
    {
        get => GetInt("minSplit", 5120);
        init
        {
            if (SplitCount == 0)
            {
                throw new InvalidOperationException("MinSplit can only be set when SplitCount is not 0");
            }
            SetProperty("minSplit", value);
        }
    }

    /// <summary>
    /// Validate symlinks are pointing to existing and unchanged files
    /// </summary>
    /// <remarks>
    /// Validation is done by comparing file's sha1.
    /// Applicable to files and not directories.
    /// </remarks>
    [YamlIgnore]
    public bool? ValidateSymlinks
    {
        get => GetBool("validateSymlinks", false);
        init => SetProperty("validateSymlinks", value);
    }

    /// <summary>
    /// Path to sync and delete files from in the local file system
    /// </summary>
    /// <remarks>
    /// If you'd like to sync dependencies after the download, set a specific local file system path. Leave empty otherwise.\nIf set, after the download completes, this path will include only the dependencies downloaded during this download operation. The other files under this path will be deleted.
    /// </remarks>
    [YamlIgnore]
    public string? SyncDeletesPathLocal
    {
        get => GetString("syncDeletesPathLocal");
        init => SetProperty("syncDeletesPathLocal", value);
    }
}