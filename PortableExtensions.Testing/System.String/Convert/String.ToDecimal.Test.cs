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
        public void ToDecimalTestCase()
        {
            var value = new Decimal( 100.120 );
            var actual = value.ToString( CultureInfo.CurrentCulture ).Replace( ",", "." ).ToDecimal();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCaseNullCheck()
        {
            StringEx.ToDecimal( null );
        }

        [TestCase]
        public void ToDecimalTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var value = new Decimal( 1123123.12 );
            var actual = value.ToString( culture ).ToDecimal( culture );

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCase1NullCheck()
        {
            StringEx.ToDecimal( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCase1NullCheck1()
        {
            "".ToDecimal( null );
        }
    }
}