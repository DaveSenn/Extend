#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void ToDateTimeTestCase()
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDateTimeTestCaseNullCheck()
        {
            ObjectEx.ToDateTime( null );
        }

        [TestCase]
        public void ToDateTimeTestCase1()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = ObjectEx.ToDateTime( value, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDateTimeTestCase1NullCheck()
        {
            ObjectEx.ToDateTime( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDateTimeTestCase1NullCheck1()
        {
            ObjectEx.ToDateTime( DateTime.Now.ToString(), null );
        }
    }
}