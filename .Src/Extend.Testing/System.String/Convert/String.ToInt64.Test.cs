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
        public void ToInt64TestCase()
        {
            var value = (Int64) RandomValueEx.GetRandomInt32();
            var actual = value.ToString()
                              .ToInt64();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt64TestCase1()
        {
            var value = (Int64) RandomValueEx.GetRandomInt32();
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToInt64( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt64TestCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToInt64( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt64TestCase1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".ToInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt64TestCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}