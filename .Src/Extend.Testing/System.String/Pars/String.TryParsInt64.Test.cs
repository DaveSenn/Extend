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
        public void TryParsInt64TestCase()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var result = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsInt64( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt64TestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var result = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( culture )
                                 .TryParsInt64( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt64TestCase1NullCheck()
        {
            var outValue = (Int64) RandomValueEx.GetRandomInt32();
            Action test = () => StringEx.TryParsInt64( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt64TestCase1NullCheck1()
        {
            var outValue = (Int64) RandomValueEx.GetRandomInt32();
            Action test = () => "".TryParsInt64( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt64TestCaseNullCheck()
        {
            var outValue = (Int64) RandomValueEx.GetRandomInt32();
            Action test = () => StringEx.TryParsInt64( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}