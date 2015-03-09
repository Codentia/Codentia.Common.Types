namespace MattchedIT.Common
{
    /// <summary>
    /// Order Interface
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Gets the payment address.
        /// </summary>
        /// <value>The payment address.</value>
        IAddress PaymentAddress
        {
            get;
        }

        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <value>The contact.</value>
        IContactDetails Contact
        {
            get;
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <value>The total.</value>
        decimal Total
        {
            get;
        }

        /// <summary>
        /// Gets the reference.
        /// </summary>
        /// <value>The reference.</value>
        string Reference
        {
            get;
        }
    }
}
