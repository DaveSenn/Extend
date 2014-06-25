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
        [TestCase]
        public void SaveToInt64TestCase()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToInt64();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToInt64TestCase1()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToInt64TestCase2()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToInt64TestCase3()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToInt64TestCaseNullCheck()
        {
            StringEx.SaveToInt64( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToInt64TestCaseNullCheck1()
        {
            "".SaveToInt64( NumberStyles.AllowExponent, null );
        }
    }
}