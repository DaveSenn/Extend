#region Usings

using System;
using System.Globalization;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void SafeToCultureInfoTest()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest1()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest2()
        {
            const String culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = culture.SafeToCultureInfo();

            Assert.Null( actual );
        }

        [Fact]
        public void SafeToCultureInfoTest3()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo();

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest4()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo();

            Assert.Null( actual );
        }

        [Fact]
        public void SafeToCultureInfoTest5()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "it-CH" ) );

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest6()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "fr-CH" ) );

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest7()
        {
            const String culture = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            var actual = culture.SafeToCultureInfo( new CultureInfo( "de-CH" ) );

            Assert.Equal( "de-CH", actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest8()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo( new CultureInfo( "en-GB" ) );

            Assert.Equal( culture, actual.Name );
        }

        [Fact]
        public void SafeToCultureInfoTest9()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "es" ) );

            Assert.Equal( "es", actual.Name );
        }
    }
}