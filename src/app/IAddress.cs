namespace Codentia.Common
{
    /// <summary>
    /// This interface must be implemented by all objects which are to be treated as Addresses
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Gets the first name.
        /// </summary>
        string FirstName
        {
            get;
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        string LastName
        {
            get;
        }

        /// <summary>
        /// Gets the HouseName
        /// </summary>
        string HouseName
        {
            get;
        }

        /// <summary>
        /// Gets the Street
        /// </summary>
        string Street
        {
            get;
        }

        /// <summary>
        /// Gets the Town
        /// </summary>
        string Town
        {
            get;
        }

        /// <summary>
        /// Gets the City
        /// </summary>
        string City
        {
            get;
        }

        /// <summary>
        /// Gets the County
        /// </summary>
        string County
        {
            get;
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        string Country
        {
            get;
        }

        /// <summary>
        /// Gets the Postcode
        /// </summary>
        string Postcode
        {
            get;
        }

        /// <summary>
        /// Concatenates the address.
        /// </summary>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="isPostCodeRequired">if set to <c>true</c> [is post code required].</param>
        /// <returns>string of concatenated address</returns>
        string ConcatenateAddress(string delimiter, bool isPostCodeRequired);
    }
}
