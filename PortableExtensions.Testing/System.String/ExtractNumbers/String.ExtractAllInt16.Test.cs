#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void ExtractAllInt16TestCase()
        {
            var value0 = 100;
            var value1 = 102;
            var value2 = -1100;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 );
            var actual = stringValue.ExtractAllInt16( 0 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );

            actual = "10.10".ExtractAllInt16( 0 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 10, actual[0] );
            Assert.AreEqual( 10, actual[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllInt16TestCaseNullCheck()
        {
            StringEx.ExtractAllInt16( null );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllInt16TestCaseNullCheck1()
        {
            StringEx.ExtractAllInt16( null, 0 );
        }
    }
}