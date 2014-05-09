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
        [TestCase]
        public void ExtractFirstDecimalTestCase()
        {
            var value0 = new Decimal( 100.2 );
            var value1 = new Decimal( 100.212 );
            var value2 = new Decimal( -1100.2231232 );
            var value3 = new Decimal( 12300 );

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstDecimal( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                    StringComparison.Ordinal ) );
            Assert.AreEqual( value1, actual );

            actual = stringValue.ExtractFirstDecimal();
            Assert.AreEqual( value0, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractFirstDecimalTestCaseNullCheck()
        {
            StringEx.ExtractFirstDecimal( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractFirstDecimalTestCaseNullCheck1()
        {
            StringEx.ExtractFirstDecimal( null, 0 );
        }
    }
}