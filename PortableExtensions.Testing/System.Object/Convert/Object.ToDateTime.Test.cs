#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToDateTimeTestCase ()
        {
            var expected = DateTime.Now;
            var value = expected.ToString();
            var actual = ObjectEx.ToDateTime( value );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void ToDateTimeTestCase1 ()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = value.ToDateTime( CultureInfo.InvariantCulture );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCase1NullCheck ()
        {
            ObjectEx.ToDateTime( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCase1NullCheck1 ()
        {
            DateTime.Now.ToString().ToDateTime( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDateTimeTestCaseNullCheck ()
        {
            ObjectEx.ToDateTime( null );
        }
    }
}