#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToCharTestCase()
        {
            const Char expected = 'a';
            var value = expected.ToString();
            var actual = ObjectEx.ToChar( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ToCharTestCaseInvalidCastException()
        {
            const String expected = "ab";
            var value = expected.ToString();
            var actual = ObjectEx.ToChar(value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharTestCaseNullCheck()
        {
            ObjectEx.ToChar( null );
        }
    }
}