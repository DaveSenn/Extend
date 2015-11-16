#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToCharByCodeTestCase()
        {
            var charValue = 'a';
            var value = charValue.ToString();
            var expected = Convert.ToChar( value );
            var actual = value.ToCharByCode();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToCharByCodeTestCase1()
        {
            var charValue = 'a';
            var value = charValue.ToString();
            var expected = Convert.ToChar( value );
            var actual = value.ToCharByCode( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToCharByCodeTestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToCharByCode( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToCharByCodeTestCase1NullCheck1()
        {
            Action test = () => "false".ToCharByCode( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToCharByCodeTestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToCharByCode( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}