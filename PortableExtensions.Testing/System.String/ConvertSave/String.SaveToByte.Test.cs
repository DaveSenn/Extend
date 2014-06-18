#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void SaveToByteTestCase()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToByte();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToByteTestCase1()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToByteTestCaseNullCheck()
        {
            StringEx.SaveToByte( null );
        }

        [TestCase]
        public void SaveToByteTestCase2()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToByteTestCase3()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                                                    expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToByteTestCaseNullCheck1()
        {
            "".SaveToByte( NumberStyles.AllowDecimalPoint, null );
        }
    }
}