#region Usings

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
        public void ToDecimalTestCase ()
        {
            var value = new Decimal( 100.120 );
            var actual = value.ToString( CultureInfo.CurrentCulture ).Replace( ",", "." ).ToDecimal();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDecimalTestCase1 ()
        {
            var culture = new CultureInfo( "en-US" );
            var value = new Decimal( 1123123.12 );
            var actual = value.ToString( culture ).ToDecimal( culture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDecimalTestCase1NullCheck ()
        {
            StringEx.ToDecimal( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDecimalTestCase1NullCheck1 ()
        {
            "".ToDecimal( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDecimalTestCaseNullCheck ()
        {
            StringEx.ToDecimal( null );
        }
    }
}