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
        public void SaveToCharTest()
        {
            const Char expected = 'c';
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToChar();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToCharTest1()
        {
            const Char expected = 'c';
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToChar( 'e' );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToCharTest2()
        {
            const Char expected = 'a';
            var actual = "InvalidValue".SaveToChar( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToCharTest3()
        {
            var actual = "InvalidValue".SaveToChar();

            Assert.AreEqual( default(Char), actual );
        }

        [Test]
        public void SaveToCharTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.SaveToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}