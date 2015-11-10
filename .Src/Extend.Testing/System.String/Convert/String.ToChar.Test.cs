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
        public void ToCharTestCase()
        {
            var value = 'a';
            var actual = value.ToString()
                              .ToChar();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToCharTestCase1()
        {
            var value = 'a';
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToChar( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToCharTestCase1NullCheck()
        {
            Action test = () => StringEx.ToChar( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToCharTestCase1NullCheck1()
        {
            Action test = () => "".ToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToCharTestCaseNullCheck()
        {
            Action test = () => StringEx.ToChar( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}