using System.Linq;

namespace coreTool.Common.EnvironmentInfo
{
    internal class StartupContext : IStartupContext
    {
        internal const string APPDATA = "data";
        internal const string DEBUG = "d";
        internal const string HELP = "h";
        internal const string INSTALL = "i";
        internal const string UNINSTALL = "u";
        internal const string CREATEMOUNTS = "m";
        internal const string TERMINATE = "terminateexisting";
        internal const string RESTART = "restart";
        internal const string EXIT_IMMEDIATELY = "exitimmediately";

        internal StartupContext(params string[] args)
        {
            Flags = new HashSet<string>();
            Args = new Dictionary<string, string>();

            foreach (var s in args)
            {
                var flag = s.Trim(' ', '/', '-');

                var argParts = flag.Split('=');

                if (argParts.Length == 2)
                {
                    Args.Add(argParts[0].Trim().ToLower(), argParts[1].Trim(' ', '"'));
                }
                else
                {
                    Flags.Add(flag.ToLower());
                }
            }
        }

        public HashSet<string> Flags { get; private set; }
        public Dictionary<string, string> Args { get; private set; }

        public bool Debug => Flags.Contains(DEBUG);
        public bool Help => Flags.Contains(HELP);
        public bool Install => Flags.Contains(INSTALL);
        public bool Uninstall => Flags.Contains(UNINSTALL);
        public bool CreateMounts => Flags.Contains(CREATEMOUNTS);
        internal bool ExitImmediately => Flags.Contains(EXIT_IMMEDIATELY);

        public string PreservedArguments
        {
            get
            {
                var args = "";

                if (Args.ContainsKey(APPDATA))
                {
                    args = "/data=" + Args[APPDATA];
                }

                return args.Trim();
            }
        }


    }
}
