using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace Codentia.Common.Types.Test
{
    /// <summary>
    /// Unit testing framework for exceptions
    /// </summary>
    [TestFixture]
    public class ExceptionTest : ISerializable   
    {
         private SerializationInfo _info;
         private StreamingContext _context;

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

            Exception ex = new InvalidEmailAddressException("Message", new Exception("Inner exception."));
            string exceptionToString = ex.ToString();

            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, ex);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                ex = (InvalidEmailAddressException)bf.Deserialize(ms);
            }

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.AreEqual(exceptionToString, ex.ToString(), "ex.ToString()");

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

            bf = new BinaryFormatter();
            ex = new DuplicateEmailAddressException("Message", new Exception("Inner exception."));
            exceptionToString = ex.ToString();

            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, ex);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                ex = (DuplicateEmailAddressException)bf.Deserialize(ms);
            }

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.AreEqual(exceptionToString, ex.ToString(), "ex.ToString()");

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

            bf = new BinaryFormatter();
            ex = new InvalidPasswordException("Message", new Exception("Inner exception."));
            exceptionToString = ex.ToString();

            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, ex);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                ex = (InvalidPasswordException)bf.Deserialize(ms);
            }

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.AreEqual(exceptionToString, ex.ToString(), "ex.ToString()");
        }        

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _info = info;
            _context = context;
        }
    }
}
