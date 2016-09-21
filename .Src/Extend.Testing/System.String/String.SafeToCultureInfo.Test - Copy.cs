#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SafeToCultureInfoTest()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest1()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest2()
        {
            const String culture = null;
            var actual = culture.SafeToCultureInfo();

            Assert.IsNull( actual );
        }

        [Test]
        public void SafeToCultureInfoTest3()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest4()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo();

            Assert.IsNull( actual );
        }

        [Test]
        public void SafeToCultureInfoTest5()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "it-CH" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest6()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "fr-CH" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest7()
        {
            const String culture = null;
            var actual = culture.SafeToCultureInfo( new CultureInfo( "de-CH" ) );

            Assert.AreEqual( "de-CH", actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest8()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo( new CultureInfo( "en-GB" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTest9()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "es" ) );

            Assert.AreEqual( "es", actual.Name );
        }
    }
}