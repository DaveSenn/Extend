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
        public void ToCultureInfoTestCase()
        {
            const String culture = "en";
            var actual = culture.ToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void ToCultureInfoTestCase1()
        {
            const String culture = "de-CH";
            var actual = culture.ToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToCultureInfoTestCase1NullCheck()
        {
            const String culture = null;
            var actual = culture.ToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        public void ToCultureInfoTestCase2()
        {
            var culture = String.Empty;
            var actual = culture.ToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }

        [Test]
        [ExpectedException( typeof (CultureNotFoundException) )]
        public void ToCultureInfoTestCase3()
        {
            const String culture = "invalidCultureName";
            var actual = culture.ToCultureInfo();

            Assert.AreEqual( culture, actual.Name );
        }
    }
}