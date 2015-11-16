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
        public void TryParsDecimalTestCase()
        {
            var expected = new Decimal( 100.123123 );
            var result = new Decimal( 100 );
            ;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsDecimal( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsDecimalTestCaseNullCheck()
        {
            var outValue = new Decimal( 100 );
            Action test = () => StringEx.TryParsDecimal( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}