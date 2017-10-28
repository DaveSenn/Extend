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
        public void ExtractFirstInt32Test()
        {
            const Int32 value0 = 100;
            const Int32 value1 = 102;
            const Int32 value2 = -1100;
            const Int32 value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstInt32( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                    StringComparison.Ordinal ) );
            Assert.Equal( value1, actual );

            actual = stringValue.ExtractFirstInt32();
            Assert.Equal( value0, actual );
        }

        [Fact]
        public void ExtractFirstInt32Test1()
        {
            const String sValue = "asdf-100asdf";
            var actual = sValue.ExtractFirstInt32();

            Assert.Equal( -100, actual );
        }

        [Fact]
        public void ExtractFirstInt32TestArgumentOutOfRangeException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ExtractFirstInt32( 100 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstInt32TestArgumentOutOfRangeException1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ExtractFirstInt32( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstInt32TestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstInt32( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExtractFirstInt32TestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstInt32( null, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}