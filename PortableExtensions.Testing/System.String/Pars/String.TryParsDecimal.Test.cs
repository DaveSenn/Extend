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
        public void TryParsDecimalTestCase()
        {
            var expected = new Decimal( 100.123123 );
            var result = new Decimal( 100 );
            ;
            var actual = expected.ToString( CultureInfo.InvariantCulture ).TryParsDecimal( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsDecimalTestCaseNullCheck()
        {
            var outValue = new Decimal( 100 );
            StringEx.TryParsDecimal( null, out outValue );
        }
    }
}