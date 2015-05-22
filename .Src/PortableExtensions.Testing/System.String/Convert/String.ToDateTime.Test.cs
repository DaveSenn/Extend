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
        public void ToDateTimeTestCase()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDateTime();

            Assert.AreEqual( value.Year, actual.Year );
            Assert.AreEqual( value.Month, actual.Month );
            Assert.AreEqual( value.Day, actual.Day );
            Assert.AreEqual( value.Hour, actual.Hour );
            Assert.AreEqual( value.Minute, actual.Minute );
            Assert.AreEqual( value.Second, actual.Second );
        }

        [Test]
        public void ToDateTimeTestCase1()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDateTime( CultureInfo.CurrentCulture );

            Assert.AreEqual( value.Year, actual.Year );
            Assert.AreEqual( value.Month, actual.Month );
            Assert.AreEqual( value.Day, actual.Day );
            Assert.AreEqual( value.Hour, actual.Hour );
            Assert.AreEqual( value.Minute, actual.Minute );
            Assert.AreEqual( value.Second, actual.Second );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCase1NullCheck()
        {
            StringEx.ToDateTime( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCase1NullCheck1()
        {
            "".ToDateTime( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCaseNullCheck()
        {
            StringEx.ToDateTime( null );
        }
    }
}