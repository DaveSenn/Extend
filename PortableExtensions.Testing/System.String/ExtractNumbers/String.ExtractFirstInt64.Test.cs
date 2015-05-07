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
        public void ExtractFirstInt64TestCase()
        {
            var value0 = 100;
            var value1 = 102;
            var value2 = -1100;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstInt64( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                    StringComparison.Ordinal ) );
            Assert.AreEqual( value1, actual );

            actual = stringValue.ExtractFirstInt64();
            Assert.AreEqual( value0, actual );
        }

        [Test]
        public void ExtractFirstInt64TestCase1()
        {
            var sValue = "asdf-100asdf";
            var actual = sValue.ExtractFirstInt64();

            Assert.AreEqual( -100, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractFirstInt64TestCaseNullCheck()
        {
            StringEx.ExtractFirstInt64( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractFirstInt64TestCaseNullCheck1()
        {
            StringEx.ExtractFirstInt64( null, 0 );
        }
    }
}