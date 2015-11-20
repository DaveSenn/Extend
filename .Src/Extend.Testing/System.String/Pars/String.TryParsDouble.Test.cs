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
        public void TryParsDoubleTestCase()
        {
            var expected = 100.123d;
            var result = 100d;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsDouble( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsDoubleTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = 100.123d;
            var result = 100d;
            var actual = expected.ToString( culture )
                                 .TryParsDouble( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsDoubleTestCase1NullCheck()
        {
            var outValue = 100d;
            Action test = () => StringEx.TryParsDouble( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDoubleTestCase1NullCheck1()
        {
            var outValue = 100d;
            Action test = () => "100".TryParsDouble( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsDoubleTestCaseNullCheck()
        {
            var outValue = 100d;
            Action test = () => StringEx.TryParsDouble( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}