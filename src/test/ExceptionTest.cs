using System;
using NUnit.Framework;

namespace Codentia.Common.Types.Test
{
    /// <summary>
    /// Unit testing framework for exceptions
    /// </summary>
    [TestFixture]
    public class ExceptionTest
    {
        /// <summary>
        /// Scenario: Throw exceptions
        /// Expected: Success
        /// </summary>
        [Test]
        public void _001_TestAllExceptions()
        {
            Assert.That(delegate { throw new InvalidEmailAddressException("invalid email1"); }, Throws.TypeOf<InvalidEmailAddressException>().With.Message.EqualTo("invalid email1"));            
            Assert.That(delegate { throw new InvalidEmailAddressException("invalid email2", new ArgumentException("arg exception")); }, Throws.TypeOf<InvalidEmailAddressException>().With.Message.EqualTo("invalid email2"));

            try
            {
                throw new InvalidEmailAddressException("invalid email3"); 
            }
            catch (Exception myex)
            {
                Assert.That(myex is ArgumentException, Is.True);
            }

            Assert.That(delegate { throw new DuplicateEmailAddressException("duplicate email1"); }, Throws.TypeOf<DuplicateEmailAddressException>().With.Message.EqualTo("duplicate email1"));
            Assert.That(delegate { throw new DuplicateEmailAddressException("duplicate email2", new ArgumentException("arg exception")); }, Throws.TypeOf<DuplicateEmailAddressException>().With.Message.EqualTo("duplicate email2"));

            try
            {
                throw new DuplicateEmailAddressException("duplicate email3");
            }
            catch (Exception myex)
            {
                Assert.That(myex is ArgumentException, Is.True);
            }

            Assert.That(delegate { throw new InvalidPasswordException("invalid password1"); }, Throws.TypeOf<InvalidPasswordException>().With.Message.EqualTo("invalid password1"));
            Assert.That(delegate { throw new InvalidPasswordException("invalid password2", new ArgumentException("arg exception")); }, Throws.TypeOf<InvalidPasswordException>().With.Message.EqualTo("invalid password2"));

            try
            {
                throw new InvalidPasswordException("invalid password3");
            }
            catch (Exception myex)
            {
                Assert.That(myex is ArgumentException, Is.True);
            }
        }
    }
}
