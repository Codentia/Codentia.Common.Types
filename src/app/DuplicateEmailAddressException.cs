using System;

namespace MattchedIT.Common
{
    /// <summary>
    /// DuplicateEmailAddressException class - exception class for Email Validation
    /// </summary>
    public class DuplicateEmailAddressException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEmailAddressException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        public DuplicateEmailAddressException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEmailAddressException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        /// <param name="innerException">Inner Exception</param>
        public DuplicateEmailAddressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}