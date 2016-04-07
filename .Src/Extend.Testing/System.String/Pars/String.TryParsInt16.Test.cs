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
        public void TryParsInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var result = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsInt16( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt16Test1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = RandomValueEx.GetRandomInt16();
            var result = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( culture )
                                 .TryParsInt16( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsInt16Test1NullCheck1()
        {
            var outValue = RandomValueEx.GetRandomInt16();
            Action test = () => "".TryParsInt16( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}