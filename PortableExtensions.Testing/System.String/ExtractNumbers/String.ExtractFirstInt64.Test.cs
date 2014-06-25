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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractFirstInt64TestCaseNullCheck()
        {
            StringEx.ExtractFirstInt64( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractFirstInt64TestCaseNullCheck1()
        {
            StringEx.ExtractFirstInt64( null, 0 );
        }
    }
}