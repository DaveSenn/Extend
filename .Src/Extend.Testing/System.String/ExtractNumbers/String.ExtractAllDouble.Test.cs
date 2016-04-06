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
        public void ExtractAllDoubleTest()
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
        public void ExtractAllDoubleTestArgumentOutOfRangeException()
        {
            Action test = () => "100.1".ExtractAllDouble( 100 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ExtractAllDoubleTestArgumentOutOfRangeException1()
        {
            Action test = () => "100.1".ExtractAllDouble( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ExtractAllDoubleTestNullCheck()
        {
            Action test = () => StringEx.ExtractAllDouble( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractAllDoubleTestNullCheck1()
        {
            Action test = () => StringEx.ExtractAllDouble( null, 0 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}