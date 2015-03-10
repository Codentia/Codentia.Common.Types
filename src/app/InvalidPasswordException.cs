using System;

namespace Codentia.Common
{
    /// <summary>
    /// InvalidPasswordException class - exception class for Email Validation
    /// </summary>
    public class InvalidPasswordException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPasswordException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        public InvalidPasswordException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPasswordException"/> class.
        /// </summary>        
        /// <param name="message">Internal message</param>
        /// <param name="innerException">Inner Exception</param>
        public InvalidPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
