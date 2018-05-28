#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ExtractAllDoubleTest()
        {
            const Double value0 = 100.2d;
            const Double value1 = 100.212d;
            const Double value2 = -1100.2231232d;
            const Double value3 = 12300d;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );
            var actual = stringValue.ExtractAllDouble();

            Assert.Equal( 4, actual.Count );
            Assert.Equal( value0, actual[0] );
            Assert.Equal( value1, actual[1] );
            Assert.Equal( value2, actual[2] );
            Assert.Equal( value3, actual[3] );
        }

        [Fact]
        public void ExtractAllDoubleTestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100.1".ExtractAllDouble( 100 );

            Assert.Throws<ArgumentOutOfRangeException>( test );
        }

        [Fact]
        public void ExtractAllDoubleTestArgumentOutOfRangeException1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100.1".ExtractAllDouble( -1 );

            Assert.Throws<ArgumentOutOfRangeException>( test );
        }

        [Fact]
        public void ExtractAllDoubleTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractAllDouble( null );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ExtractAllDoubleTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractAllDouble( null, 10 );

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}