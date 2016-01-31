using System;
using System.Runtime.Serialization;

namespace Codentia.Common
{
    /// <summary>
    /// DuplicateEmailAddressException class - exception class for Email Validation
    /// </summary>
    [Serializable]
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
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public DuplicateEmailAddressException(SerializationInfo info, StreamingContext context)
            : base(info, context)
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