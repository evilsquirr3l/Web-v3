using System;

namespace Business.Implementation.Validation
{
    public class BusinessException : Exception
    {
        private const string DefaultMessage = "An error has occurred.";

        public BusinessException() : base(DefaultMessage)
        {

        }

        public BusinessException(string message) : base(message)
        {
            
        }
    }
}