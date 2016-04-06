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
        public void TryParsInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var result = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsInt32( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt32Test1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = RandomValueEx.GetRandomInt32();
            var result = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( culture )
                                 .TryParsInt32( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt32Test1NullCheck()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            Action test = () => StringEx.TryParsInt32( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt32Test1NullCheck1()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            Action test = () => "".TryParsInt32( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsInt32TestNullCheck()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            Action test = () => StringEx.TryParsInt32( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}