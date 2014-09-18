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
        public void ToDecimalTestCase()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture ).Replace( ".", "," );
            var actual = ObjectEx.ToDecimal( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCaseNullCheck()
        {
            ObjectEx.ToDecimal( null );
        }

        [Test]
        public void ToDecimalTestCase1()
        {
            var expected = new Decimal( 100.12 );
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = ObjectEx.ToDecimal( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCase1NullCheck()
        {
            ObjectEx.ToDecimal( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDecimalTestCase1NullCheck1()
        {
            ObjectEx.ToDecimal( "false", null );
        }
    }
}