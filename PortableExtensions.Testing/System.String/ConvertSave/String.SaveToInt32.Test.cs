#region Usings

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
        public void SaveToInt32TestCase ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToInt32();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase1 ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase2 ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase3 ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase4 ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture ).SaveToInt32( RandomValueEx.GetRandomInt32() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase5 ()
        {
            var actual = "InvalidValue".SaveToInt32();

            Assert.AreEqual( default( Int32 ), actual );
        }

        [Test]
        public void SaveToInt32TestCase6 ()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt32() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32TestCase7 ()
        {
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default( Int32 ), actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SaveToInt32TestCaseNullCheck ()
        {
            StringEx.SaveToInt32( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SaveToInt32TestCaseNullCheck1 ()
        {
            "".SaveToInt32( NumberStyles.AllowExponent, null );
        }
    }
}