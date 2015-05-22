#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SafeToCultureInfoTestCase()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase1()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase2()
        {
            const String culture = null;
            var actual = culture.SafeToCultureInfo();

            Assert.IsNull( actual );
        }

        [Test]
        public void SafeToCultureInfoTestCase3()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase4()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo();

            Assert.IsNull( actual );
        }

        [Test]
        public void SafeToCultureInfoTestCase5()
        {
            const String culture = "en";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "it-CH" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase6()
        {
            const String culture = "de-CH";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "fr-CH" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase7()
        {
            const String culture = null;
            var actual = culture.SafeToCultureInfo( new CultureInfo( "de-CH" ) );

            Assert.AreEqual( "de-CH", actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase8()
        {
            var culture = String.Empty;
            var actual = culture.SafeToCultureInfo( new CultureInfo( "en-GB" ) );

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void SafeToCultureInfoTestCase9()
        {
            const String culture = "invalidCultureName";
            var actual = culture.SafeToCultureInfo( new CultureInfo( "es" ) );

            Assert.AreEqual( "es", actual.Name );
        }
    }
}