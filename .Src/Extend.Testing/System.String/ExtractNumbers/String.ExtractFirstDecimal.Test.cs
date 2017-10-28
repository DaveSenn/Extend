#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void ExtractFirstDecimalTest()
        {
            var value0 = new Decimal( 100.2 );
            var value1 = new Decimal( 100.212 );
            var value2 = new Decimal( -1100.2231232 );
            var value3 = new Decimal( 12300 );

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstDecimal( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                      StringComparison.Ordinal ) );
            Assert.Equal( value1, actual );

            actual = stringValue.ExtractFirstDecimal();
            Assert.Equal( value0, actual );
        }

        [Fact]
        public void ExtractFirstDecimalTest1()
        {
            const String sValue = "asdf-100.1234asdf";
            var actual = sValue.ExtractFirstDecimal();

            Assert.Equal( -100.1234m, actual );
        }

        [Fact]
        public void ExtractFirstDecimalTest1ArgumentOutOfRangeException()
        {
            var sValue = RandomValueEx.GetRandomString();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => sValue.ExtractFirstDecimal( sValue.Length );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstDecimalTest2ArgumentOutOfRangeException()
        {
            var sValue = RandomValueEx.GetRandomString();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => sValue.ExtractFirstDecimal( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstDecimalTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstDecimal( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExtractFirstDecimalTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstDecimal( null, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}