#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToDecimalTestCase()
        {
            var value = new Decimal( 100.120 );
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .Replace( ",", "." )
                              .ToDecimal();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDecimalTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var value = new Decimal( 1123123.12 );
            var actual = value.ToString( culture )
                              .ToDecimal( culture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDecimalTestCase1NullCheck()
        {
            Action test = () => StringEx.ToDecimal( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalTestCase1NullCheck1()
        {
            Action test = () => "".ToDecimal( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalTestCaseNullCheck()
        {
            Action test = () => StringEx.ToDecimal( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}