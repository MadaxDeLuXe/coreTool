using coreTool.Common.EnvironmentInfo;
using coreTool.Common.Exceptions;

namespace coreTool
{
    internal class ConsoleApp
    {
        //TODO: Logger

        public enum ApplicationModes
        {
            Debug,
            Help,
            Install,
            Uninstall,
            CreateMounts
        }

        private enum ExitCodes
        {
            Normal = 0,
            UnknownFailure = 1,
            RecoverableFailure = 2,
            NonRecoverableFailure = 3
        }

        static void Main(string[] args)
        {
            StartupContext startupArgs = null;

            try
            {
                startupArgs = new StartupContext(args);
                try
                {
                    //NzbDroneLogger.Register(startupArgs, false, true);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("NLog Exception: " + ex.ToString());
                    throw;
                }
                
                Bootstrap.Start(args);

            }
            catch (StartupException ex)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                //TODO: Logger.Fatal(ex, "MEGAFAIL!");
                Exit(ExitCodes.NonRecoverableFailure, startupArgs);
            }
        }
        private static void Exit(ExitCodes exitCode, StartupContext? startupArgs)
        {
            if (exitCode != ExitCodes.Normal)
            {
                System.Console.WriteLine("Press enter to exit...");

                Thread.Sleep(1000);

                if (exitCode == ExitCodes.NonRecoverableFailure)
                {
                    if (startupArgs?.ExitImmediately == true)
                    {
                        System.Console.WriteLine("Exiting... (ExitImmediately: true)");

                        Environment.Exit((int)exitCode);
                    }

                    System.Console.WriteLine("Exiting... (ExitImmediately: false)");
                    for (var i = 0; i < 3600; i++)
                    {
                        Thread.Sleep(1000);
                        if (!System.Console.IsInputRedirected && System.Console.KeyAvailable)
                        {
                            break;
                        }
                    }
                }

                // ReadLine silently succeeds if no console present, KeyAvailable doesn't.
                System.Console.ReadLine();
            }

            Environment.Exit((int)exitCode);
        }
    }
}
