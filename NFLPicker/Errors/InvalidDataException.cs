using System;

namespace NFLPicker.Errors
{
    public class InvalidDataException : ApplicationException
    {
        public InvalidDataException(string message)
            : base(message)
        {

        }
    }
}
