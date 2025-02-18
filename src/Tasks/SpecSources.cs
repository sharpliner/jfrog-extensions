namespace Sharpliner.Extensions.JFrogTasks;

public enum SpecSources
{
    [YamlMember(Alias = "taskConfiguration")]
    TaskConfiguration,

    [YamlMember(Alias = "file")]
    File
}