#region Usings

using System;
using System.Globalization;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToDecimalTestCase()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo( "en-US" );

            var expected = new Decimal( 100.12 );
            var value = expected.ToString( Thread.CurrentThread.CurrentCulture );
            var actual = ObjectEx.ToDecimal( value );
            Assert.AreEqual( expected, actual );
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
        public void ToDecimalTestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToDecimal( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalTestCase1NullCheck1()
        {
            Action test = () => ObjectEx.ToDecimal( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimalTestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToDecimal( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}