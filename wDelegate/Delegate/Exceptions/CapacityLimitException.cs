using System;

namespace Delegate.Exceptions
{
    public class CapacityLimitException : Exception
    {
        public CapacityLimitException(string message) : base(message)
        {
            
        }
    }
}