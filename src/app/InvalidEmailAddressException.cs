using System;

namespace MattchedIT.Common
{
    /// <summary>
    /// InvalidEmailAddressException class - exception class for Email Validation
    /// </summary>
    public class InvalidEmailAddressException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEmailAddressException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        public InvalidEmailAddressException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEmailAddressException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        /// <param name="innerException">Inner Exception</param>
        public InvalidEmailAddressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
