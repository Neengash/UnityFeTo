using System;

namespace FeTo.Exceptions
{
    public class FeToException : Exception
    {
        public FeToException() : base() { }
        public FeToException(string message) : base(message) { }
    }
}
