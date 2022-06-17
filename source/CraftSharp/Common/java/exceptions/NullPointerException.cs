using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.Common.java.exceptions
{
    public class NullPointerException : Exception
    {
        public NullPointerException() : base() { }

        public NullPointerException(string message) : base(message) { }

        public NullPointerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
