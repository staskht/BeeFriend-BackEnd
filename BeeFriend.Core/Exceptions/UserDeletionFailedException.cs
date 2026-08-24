using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Exceptions
{
    public class UserDeletionFailedException : Exception
    {
        public UserDeletionFailedException() { }
        public UserDeletionFailedException(string message) : base(message) { }
        public UserDeletionFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
