#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToInt32TestCase()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToInt32();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase1()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase2()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase3()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToInt32TestCaseNullCheck()
        {
            StringEx.SaveToInt32( null );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToInt32TestCaseNullCheck1()
        {
            "".SaveToInt32( NumberStyles.AllowExponent, null );
        }
    }
}