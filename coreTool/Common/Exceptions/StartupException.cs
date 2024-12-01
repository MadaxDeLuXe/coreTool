

namespace coreTool.Common.Exceptions
{
    internal class StartupException : coreToolException
    {
        internal StartupException(string message, params object[] args)
            : base("Radarr failed to start: " + string.Format(message, args))
        {
        }

        internal StartupException(string message)
            : base("Radarr failed to start: " + message)
        {
        }

        internal StartupException()
            : base("Radarr failed to start")
        {
        }

        internal StartupException(Exception innerException, string message, params object[] args)
            : base("Radarr failed to start: " + string.Format(message, args), innerException)
        {
        }

        internal StartupException(Exception innerException, string message)
            : base("Radarr failed to start: " + message, innerException)
        {
        }

        internal StartupException(Exception innerException)
            : base("Radarr failed to start: " + innerException.Message)
        {
        }
    }
}
