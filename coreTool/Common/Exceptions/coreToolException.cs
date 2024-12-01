using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreTool.Common.Exceptions
{
    internal class coreToolException : ApplicationException
    {
        protected coreToolException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        protected coreToolException(string message)
            : base(message)
        {
        }

        protected coreToolException(string message, Exception innerException, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        protected coreToolException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
