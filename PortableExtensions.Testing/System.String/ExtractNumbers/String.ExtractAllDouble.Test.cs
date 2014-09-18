#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractAllDoubleTestCase()
        {
            var value0 = 100.2d;
            var value1 = 100.212d;
            var value2 = -1100.2231232d;
            var value3 = 12300d;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );
            var actual = stringValue.ExtractAllDouble( 0 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllDoubleTestCaseNullCheck()
        {
            StringEx.ExtractAllDouble( null );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ExtractAllDoubleTestCaseNullCheck1()
        {
            StringEx.ExtractAllDouble( null, 0 );
        }
    }
}