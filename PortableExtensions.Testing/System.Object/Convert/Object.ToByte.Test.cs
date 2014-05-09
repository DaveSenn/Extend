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
        [TestCase]
        public void ToByteTestCase()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCaseNullCheck()
        {
            ObjectEx.ToByte( null );
        }

        [TestCase]
        public void ToByteTestCase1()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck()
        {
            ObjectEx.ToByte( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToByteTestCase1NullCheck1()
        {
            ObjectEx.ToByte( "false", null );
        }
    }
}