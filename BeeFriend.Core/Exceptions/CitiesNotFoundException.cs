using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Exceptions
{
    public class CitiesNotFoundException : Exception
    {
        public CitiesNotFoundException() { }
        public CitiesNotFoundException(string message) : base(message) { }
        public CitiesNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
