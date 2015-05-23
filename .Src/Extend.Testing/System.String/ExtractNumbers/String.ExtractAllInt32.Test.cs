#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractAllInt32TestCase()
        {
            var value0 = 100;
            var value1 = 102;
            var value2 = -1100;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 );
            var actual = stringValue.ExtractAllInt32( 0 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );

            actual = "10.10".ExtractAllInt32( 0 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 10, actual[0] );
            Assert.AreEqual( 10, actual[1] );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void ExtractAllInt32TestCaseArgumentOutOfRangeException()
        {
            var actual = "100".ExtractAllInt32( 1000 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentOutOfRangeException) )]
        public void ExtractAllInt32TestCaseArgumentOutOfRangeException1()
        {
            var actual = "100".ExtractAllInt32( -1 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractAllInt32TestCaseNullCheck()
        {
            StringEx.ExtractAllInt32( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExtractAllInt32TestCaseNullCheck1()
        {
            StringEx.ExtractAllInt32( null, 0 );
        }
    }
}