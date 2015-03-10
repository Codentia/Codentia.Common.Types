using NUnit.Framework;

namespace Codentia.Common.Types.Test
{
    /// <summary>
    /// Unit Tests for SimpleAddress class
    /// </summary>
    [TestFixture]
    public class SimpleAddressTest
    {
        /// <summary>
        /// Scenario: Create object, check property values
        /// Expected: Values match inputs
        /// </summary>
        [Test]
        public void _001_ConstructorAndProperties()
        {
            SimpleAddress a = new SimpleAddress("first", "last", "house", "street", "town", "city", "county", "country", "postcode");
            Assert.That(a.FirstName, Is.EqualTo("first"));
            Assert.That(a.LastName, Is.EqualTo("last"));
            Assert.That(a.HouseName, Is.EqualTo("house"));
            Assert.That(a.Street, Is.EqualTo("street"));
            Assert.That(a.Town, Is.EqualTo("town"));
            Assert.That(a.City, Is.EqualTo("city"));
            Assert.That(a.County, Is.EqualTo("county"));
            Assert.That(a.Country, Is.EqualTo("country"));
            Assert.That(a.Postcode, Is.EqualTo("postcode"));
        }

        /// <summary>
        /// Scenario: Create class, call method with no postcode included
        /// Expected: Correct concatenation, no postcode
        /// </summary>
        [Test]
        public void _002_ConcatenateAddress_WithoutPostcode()
        {
            SimpleAddress a = new SimpleAddress("first", "last", "house", "street", "town", "city", "county", "country", "postcode");
            Assert.That(a.ConcatenateAddress("|", false), Is.EqualTo("first last|house|street|town|city|county|country"));
        }

        /// <summary>
        /// Scenario: Create class, call method with postcode included
        /// Expected: Correct concatenation, with postcode
        /// </summary>
        [Test]
        public void _002_ConcatenateAddress_WithPostcode()
        {
            SimpleAddress a = new SimpleAddress("first", "last", "house", "street", "town", "city", "county", "country", "postcode");
            Assert.That(a.ConcatenateAddress(",", true), Is.EqualTo("first last,house,street,town,city,county,country,postcode"));
        }
    }
}
