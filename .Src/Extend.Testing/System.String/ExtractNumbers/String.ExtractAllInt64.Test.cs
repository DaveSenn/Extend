#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractAllInt64Test()
        {
            var value0 = 100;
            var value1 = 102;
            var value2 = -1100;
            var value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 );
            var actual = stringValue.ExtractAllInt64( 0 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );

            actual = "10.10".ExtractAllInt64( 0 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 10, actual[0] );
            Assert.AreEqual( 10, actual[1] );
        }

        [Test]
        public void ExtractAllInt64TestNullCheck()
        {
            Action test = () => StringEx.ExtractAllInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractAllInt64TestNullCheck1()
        {
            Action test = () => StringEx.ExtractAllInt64( null, 0 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}