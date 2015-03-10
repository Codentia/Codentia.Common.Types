namespace Codentia.Common
{
    /// <summary>
    /// This struct represents a lightweight key/value pair, used for populating simple datastructures and controls.
    /// </summary>
    public struct LookupPair
    {
        private string _key;
        private string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupPair"/> struct.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public LookupPair(string key, string value)
        {
            _key = key;
            _value = value;
        }

        /// <summary>
        /// Gets the Key
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
        }
    }
}
