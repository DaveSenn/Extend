#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void ExtractAllDecimalTestCase()
        {
            var value0 = new Decimal( 100.2 );
            var value1 = new Decimal( 100.212 );
            var value2 = new Decimal( -1100.2231232 );
            var value3 = new Decimal( 12300 );

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                .Replace( ",", "." );
            var actual = stringValue.ExtractAllDecimal( 0 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllDecimalTestCaseNullCheck()
        {
            StringEx.ExtractAllDecimal( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllDecimalTestCaseNullCheck1()
        {
            StringEx.ExtractAllDecimal( null, 0 );
        }
    }
}