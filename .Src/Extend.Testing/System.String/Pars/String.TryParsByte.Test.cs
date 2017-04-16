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
        public void TryParsByteInvalidValueTest()
        {
            Byte result;
            var actual = "InvalidValue".TryParsByte( out result );

            result
                .Should()
                .Be( default(Byte) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsByteNullTest()
        {
            Byte result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsByte( out result );

            result
                .Should()
                .Be( default(Byte) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsByteOverloadFormatProviderNullTest()
        {
            var outValue = (Byte) 1;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => outValue.ToString()
                                        .TryParsByte( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryParsByteOverloadInvalidNumberStyleNullTest()
        {
            const Byte expected = (Byte) 10;
            Byte outValue;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expected.ToString()
                                        .TryParsByte( NumberStyles.AllowLeadingWhite, null, out outValue );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TryParsByteOverloadInvalidValueTest()
        {
            var culture = new CultureInfo( "de-CH" );
            Byte result;
            var actual = "InvalidValue".TryParsByte( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( default(Byte) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsByteOverloadNullTest()
        {
            var culture = new CultureInfo( "de-CH" );
            Byte result;
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.TryParsByte( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( default(Byte) );

            actual
                .Should()
                .BeFalse();
        }

        [Fact]
        public void TryParsByteOverloadTest()
        {
            var culture = new CultureInfo( "de-CH" );
            const Byte expected = (Byte) 1;
            Byte result;
            var actual = expected.ToString( culture )
                                 .TryParsByte( NumberStyles.Any, culture, out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }

        [Fact]
        public void TryParsByteTest()
        {
            const Byte expected = (Byte) 1;
            Byte result;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsByte( out result );

            result
                .Should()
                .Be( expected );

            actual
                .Should()
                .BeTrue();
        }
    }
}