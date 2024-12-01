namespace coreTool.Common.EnvironmentInfo
{
    internal interface IStartupContext
    {
        HashSet<string> Flags { get; }
        Dictionary<string, string> Args { get; }

        bool Debug { get; }
        bool Help { get; }
        bool Install { get; }
        bool Uninstall { get; }
        bool CreateMounts { get; }

        string PreservedArguments { get; }
    }
}
