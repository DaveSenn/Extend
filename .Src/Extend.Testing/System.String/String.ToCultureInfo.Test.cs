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
        public void ToCultureInfoTest()
        {
            const String culture = "en";
            var actual = culture.ToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void ToCultureInfoTest1()
        {
            const String culture = "de-CH";
            var actual = culture.ToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void ToCultureInfoTest1NullCheck()
        {
            const String culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => culture.ToCultureInfo();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToCultureInfoTest2()
        {
            var culture = String.Empty;
            var actual = culture.ToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void ToCultureInfoTest3()
        {
            const String culture = "invalidCultureName";
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => culture.ToCultureInfo();

            test.ShouldThrow<CultureNotFoundException>();
        }
    }
}