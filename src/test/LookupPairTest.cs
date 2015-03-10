using NUnit.Framework;

namespace Codentia.Common.Types.Test
{
    /// <summary>
    /// Unit testing framework for LookupPair struct
    /// </summary>
    [TestFixture]
    public class LookupPairTest
    {
        /// <summary>
        /// Scenario: Create instance of object, check properties match values given to constructor
        /// Expected: Values match
        /// </summary>
        [Test]
        public void _001_ConstructorAndProperties()
        {
            LookupPair lp = new LookupPair("key1", "val1");
            Assert.That(lp.Key, Is.EqualTo("key1"));
            Assert.That(lp.Value, Is.EqualTo("val1"));
        }
    }
}
