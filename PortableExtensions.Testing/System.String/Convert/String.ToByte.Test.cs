#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToByteTestCase()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString().ToByte();

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCaseNullCheck()
        {
            StringEx.ToByte( null );
        }

        [Test]
        public void ToByteTestCase1()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToByte( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck()
        {
            StringEx.ToByte( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck1()
        {
            "".ToByte( null );
        }
    }
}