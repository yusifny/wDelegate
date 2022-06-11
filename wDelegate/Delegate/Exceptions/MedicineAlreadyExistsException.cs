using System;

namespace Delegate.Exceptions
{
    public class MedicineAlreadyExistsException : Exception
    {
        public MedicineAlreadyExistsException(string message) : base(message)
        {

        }
    }
}