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
        public void ExtractAllInt32Test()
        {
            const Int32 value0 = 100;
            const Int32 value1 = 102;
            const Int32 value2 = -1100;
            const Int32 value3 = 12300;

            var stringValue = "".ConcatAll( "asd", value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 );
            var actual = stringValue.ExtractAllInt32( 1 );

            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( value0, actual[0] );
            Assert.AreEqual( value1, actual[1] );
            Assert.AreEqual( value2, actual[2] );
            Assert.AreEqual( value3, actual[3] );

            actual = "310.10".ExtractAllInt32( 1 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 10, actual[0] );
            Assert.AreEqual( 10, actual[1] );
        }

        [Test]
        public void ExtractAllInt32TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ExtractAllInt32( 1000 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ExtractAllInt32TestArgumentOutOfRangeException1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ExtractAllInt32( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ExtractAllInt32TestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractAllInt32( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractAllInt32TestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractAllInt32( null, 10 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}