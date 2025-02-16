namespace Sharpliner.Extensions.JFrogTasks;

public abstract record JFrogGenericArtifactsTask : AzureDevOpsTask
{
    protected JFrogGenericArtifactsTask(string command, string connection) : base("JFrogGenericArtifacts@1")
    {
        SetProperty("command", command);
        Connection = connection;
        SpecSource = SpecSources.TaskConfiguration;
    }

    /// <summary>
    /// Artifactory service to be used by this task.
    /// </summary>
    [YamlIgnore]
    public string Connection
    {
        get => GetString("connection")!;
        init => SetProperty("connection", value);
    }

    /// <summary>
    /// specSource
    /// </summary>
    [YamlIgnore]
    public SpecSources SpecSource
    {
        get => GetEnum("specSource", SpecSources.TaskConfiguration);
        init => SetProperty("specSource", value);
    }

    /// <summary>
    /// Use file spec from task configuration
    /// </summary>
    [YamlIgnore]
    public string? FileSpec
    {
        get => GetString("fileSpec")!;
        init
        {
            if (SpecSource != SpecSources.TaskConfiguration)
            {
                throw new InvalidOperationException("FileSpec can only be set when SpecSource is TaskConfiguration");
            }

            SetProperty("fileSpec", value);
        }
    }

    /// <summary>
    /// Use file spec from a local file
    /// </summary>
    [YamlIgnore]
    public string? File
    {
        get => GetString("file")!;
        init
        {
            if (SpecSource != SpecSources.File)
            {
                throw new InvalidOperationException("File can only be set when SpecSource is File");
            }
            SetProperty("file", value);
        }
    }

    /// <summary>
    /// Select to replace variables in your File Spec.
    /// In the File Spec
    /// </summary>
    [YamlIgnore]
    public bool? ReplaceSpecVars
    {
        get => GetBool("replaceSpecVars", false);
        init => SetProperty("replaceSpecVars", value);
    }

    /// <summary>
    /// List of Spec vars.
    /// List of variables in the form of "key1=value1;key2=value2;..." to be replaced in the File Spec.
    /// </summary>
    [YamlIgnore]
    public string? SpecVars
    {
        get => GetString("specVars");
        init => SetProperty("specVars", value);
    }

    /// <summary>
    /// Select if you'd like the task to fail if no files were affected.
    /// </summary>
    [YamlIgnore]
    public bool? FailNoOp
    {
        get => GetBool("failNoOp", true);
        init => SetProperty("failNoOp", value);
    }

    /// <summary>
    /// Skip TLS certificates verification
    /// </summary>
    [YamlIgnore]
    public bool? InsecureTls
    {
        get => GetBool("insecureTls", false);
        init => SetProperty("insecureTls", value);
    }

    /// <summary>
    /// The number of parallel threads that should be used
    /// </summary>
    [YamlIgnore]
    public int? Threads
    {
        get => GetInt("threads", 3);
        init
        {
            if (value is < 1 or > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(Threads), value, "Threads must be between 1 and 20");
            }
            SetProperty("threads", value);
        }
    }

    /// <summary>
    /// Retries.
    /// Number of HTTP retries.
    /// </summary>
    [YamlIgnore]
    public int? Retries
    {
        get => GetInt("retries", 3);
        init
        {
            if (value is < 0 or > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(Retries), value, "Retries must be between 0 and 12");
            }
            SetProperty("retries", value);
        }
    }

    /// <summary>
    /// Current working directory where the command is run.
    /// Empty is the root of the repo (build) or artifacts (release), which is $(System.DefaultWorkingDirectory)
    /// </summary>
    [YamlIgnore]
    public string? WorkingDirectory
    {
        get => GetString("workingDirectory");
        init => SetProperty("workingDirectory", value);
    }
}

public enum SpecSources
{
    [YamlMember(Alias = "taskConfiguration")]
    TaskConfiguration,

    [YamlMember(Alias = "file")]
    File
}