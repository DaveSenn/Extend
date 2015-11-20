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
        public void ToInt32TestCase()
        {
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString()
                              .ToInt32();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt32TestCase1()
        {
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToInt32( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt32TestCase1NullCheck()
        {
            Action test = () => StringEx.ToInt32( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt32TestCase1NullCheck1()
        {
            Action test = () => "".ToInt32( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt32TestCaseNullCheck()
        {
            Action test = () => StringEx.ToInt32( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}