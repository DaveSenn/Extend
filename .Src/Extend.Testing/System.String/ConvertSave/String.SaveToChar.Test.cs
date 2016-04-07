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
        public void SaveToCharInvalidValueTest()
        {
            var actual = "InvalidValue".SaveToChar();

            actual
                .Should()
                .Be( default(Char) );
        }

        [Test]
        public void SaveToCharInvalidValueWithDefaultTest()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SaveToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToCharNullTest()
        {
            String value = null;
            const Char expected = 'y';
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.SaveToChar( expected );

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToCharTest()
        {
            const Char expected = 'c';
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToChar();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void SaveToCharTest1()
        {
            const Char expected = 'c';
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToChar( 'e' );

            actual
                .Should()
                .Be( expected );
        }
    }
}