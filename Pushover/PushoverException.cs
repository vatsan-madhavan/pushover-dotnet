using System;

namespace Pushover
{
    [Serializable]
    public class PushoverException : Exception
    {
        public PushoverException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
