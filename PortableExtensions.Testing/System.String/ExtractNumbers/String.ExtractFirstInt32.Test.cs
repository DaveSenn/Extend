#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractFirstInt32TestCase ()
        {
            var value0 = 100;
            var value1 = 102;
            var value2 = -1100;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstInt32( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                    StringComparison.Ordinal ) );
            Assert.AreEqual( value1, actual );

            actual = stringValue.ExtractFirstInt32();
            Assert.AreEqual( value0, actual );
        }

        [Test]
        public void ExtractFirstInt32TestCase1 ()
        {
            var sValue = "asdf-100asdf";
            var actual = sValue.ExtractFirstInt32();

            Assert.AreEqual( -100, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void ExtractFirstInt32TestCaseArgumentOutOfRangeException ()
        {
            var actual = "100".ExtractFirstInt32( 100 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentOutOfRangeException) )]
        public void ExtractFirstInt32TestCaseArgumentOutOfRangeException1 ()
        {
            var actual = "100".ExtractFirstInt32( -1 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ExtractFirstInt32TestCaseNullCheck ()
        {
            StringEx.ExtractFirstInt32( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ExtractFirstInt32TestCaseNullCheck1 ()
        {
            StringEx.ExtractFirstInt32( null, 0 );
        }
    }
}