#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToByteTestCase()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCaseNullCheck()
        {
            ObjectEx.ToByte( null );
        }

        [Test]
        public void ToByteTestCase1()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck()
        {
            ObjectEx.ToByte( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck1()
        {
            ObjectEx.ToByte( "false", null );
        }
    }
}