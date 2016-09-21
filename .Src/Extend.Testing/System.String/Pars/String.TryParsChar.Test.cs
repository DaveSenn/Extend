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
        public void TryParsCharInvalidValueTest()
        {
            Char result;
            var actual = "InvalidValue".TryParsChar( out result );

            result
                .Should()
                .Be( default(Char) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsCharNullTest()
        {
            String value = null;
            Char result;
            var actual = value.TryParsChar( out result );

            result
                .Should()
                .Be( default(Char) );

            actual
                .Should()
                .BeFalse();
        }

        [Test]
        public void TryParsCharTest()
        {
            const Char expected = 'b';
            Char result;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsChar( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}