using System;
using System.Collections.Generic;
using System.Text;

namespace Codentia.Common
{
    /// <summary>
    /// Represents a set of contact details
    /// </summary>
    public interface IContactDetails
    {
        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <value>The email address.</value>
        string EmailAddress
        {
            get;
        }
    }
}
