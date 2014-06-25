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
        public void SaveToDecimalTestCase()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToDecimal();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToDecimalTestCase1()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SaveToDecimal( expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToDecimalTestCase2()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                .SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToDecimalTestCase3()
        {
            var expected = new Decimal( RandomValueEx.GetRandomInt32() );
            var actual = "InvalidValue".SaveToDecimal( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToDecimalTestCaseNullCheck()
        {
            StringEx.SaveToDecimal( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToDecimalTestCaseNullCheck1()
        {
            "".SaveToDouble( NumberStyles.AllowExponent, null );
        }
    }
}