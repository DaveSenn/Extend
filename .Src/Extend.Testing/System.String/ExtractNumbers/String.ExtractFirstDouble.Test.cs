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
        public void ExtractFirstDoubleTest()
        {
            const Double value0 = 100.2;
            const Double value1 = 100.212;
            const Double value2 = -1100.2231232;
            const Int32 value3 = 12300;

            var stringValue = "".ConcatAll( value0, "asdasd.)(/)(=+", value1, "a", value2, "asd", value3 )
                                .Replace( ",", "." );

            var actual =
                stringValue.ExtractFirstDouble( stringValue.IndexOf( value1.ToString( CultureInfo.InvariantCulture ),
                                                                     StringComparison.Ordinal ) );
            Assert.Equal( value1, actual );

            actual = stringValue.ExtractFirstDouble();
            Assert.Equal( value0, actual );
        }

        [Fact]
        public void ExtractFirstDoubleTest1()
        {
            const String sValue = "asdf-100.1234asdf";
            var actual = sValue.ExtractFirstDouble();

            Assert.Equal( -100.1234d, actual );
        }

        [Fact]
        public void ExtractFirstDoubleTest1ArgumentOutOfRangeException()
        {
            var sValue = RandomValueEx.GetRandomString();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => sValue.ExtractFirstDouble( sValue.Length );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstDoubleTest2ArgumentOutOfRangeException()
        {
            var sValue = RandomValueEx.GetRandomString();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => sValue.ExtractFirstDouble( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ExtractFirstDoubleTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstDouble( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExtractFirstDoubleTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ExtractFirstDouble( null, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}