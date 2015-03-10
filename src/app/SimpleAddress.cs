namespace Codentia.Common
{
    /// <summary>
    /// SimpleAddress is a basic address-holding class confirming to <see cref="IAddress"/>
    /// </summary>
    public class SimpleAddress : IAddress
    {
        private string _firstName;
        private string _lastName;
        private string _houseName;
        private string _street;
        private string _town;
        private string _city;
        private string _county;
        private string _countryName;
        private string _postcode;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAddress"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="houseName">Name of the house.</param>
        /// <param name="street">The street.</param>
        /// <param name="town">The town.</param>
        /// <param name="city">The city.</param>
        /// <param name="county">The county.</param>
        /// <param name="countryName">Name of the country.</param>
        /// <param name="postcode">The postcode.</param>
        public SimpleAddress(string firstName, string lastName, string houseName, string street, string town, string city, string county, string countryName, string postcode)
        {
            _firstName = firstName;
            _lastName = lastName;
            _houseName = houseName;
            _street = street;
            _town = town;
            _city = city;
            _county = county;
            _countryName = countryName;
            _postcode = postcode;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        /// <summary>
        /// Gets the HouseName
        /// </summary>
        public string HouseName
        {
            get
            {
                return _houseName;
            }
        }

        /// <summary>
        /// Gets the Street
        /// </summary>
        public string Street
        {
            get
            {
                return _street;
            }
        }

        /// <summary>
        /// Gets the Town
        /// </summary>
        public string Town
        {
            get
            {
                return _town;
            }
        }

        /// <summary>
        /// Gets the City
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }
        }

        /// <summary>
        /// Gets the County
        /// </summary>
        public string County
        {
            get
            {
                return _county;
            }
        }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string Country
        {
            get
            {
                return _countryName;
            }
        }

        /// <summary>
        /// Gets the Postcode
        /// </summary>
        public string Postcode
        {
            get
            {
                return _postcode;
            }
        }

        /// <summary>
        /// Concatenates the address.
        /// </summary>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="isPostCodeRequired">if set to <c>true</c> [is post code required].</param>
        /// <returns>
        /// string of concatenated address
        /// </returns>
        public string ConcatenateAddress(string delimiter, bool isPostCodeRequired)
        {
            return string.Format("{1} {2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{9}{10}", delimiter, _firstName, _lastName, _houseName, _street, _town, _city, _county, _countryName, isPostCodeRequired ? delimiter : string.Empty, isPostCodeRequired ? _postcode : string.Empty);
        }
    }
}
