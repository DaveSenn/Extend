#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void TryParsInt32TestCase()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var result = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture ).TryParsInt32( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsInt32TestCaseNullCheck()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            StringEx.TryParsInt32( null, out outValue );
        }

        [TestCase]
        public void TryParsInt32TestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = RandomValueEx.GetRandomInt32();
            var result = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( culture ).TryParsInt32( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsInt32TestCase1NullCheck()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            StringEx.TryParsInt32( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsInt32TestCase1NullCheck1()
        {
            var outValue = RandomValueEx.GetRandomInt32();
            "".TryParsInt32( NumberStyles.Any, null, out outValue );
        }
    }
}