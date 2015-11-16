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
        public void ToInt64TestCase()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt64( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt64TestCase1()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt64( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt64TestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToInt64( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt64TestCase1NullCheck1()
        {
            Action test = () => ObjectEx.ToInt64( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt64TestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}