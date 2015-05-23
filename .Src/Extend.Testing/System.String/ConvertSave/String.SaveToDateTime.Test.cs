#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToDateTimeTestCase()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime();

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase1()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SaveToDateTime( expected );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase2()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase3()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDateTimeTestCase4()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime( DateTime.MaxValue );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase5()
        {
            var expected = default( DateTime );
            var actual = "InvalidValue".SaveToDateTime();

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase6()
        {
            var expected = DateTime.Now;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, DateTime.MinValue );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTestCase7()
        {
            var expected = default( DateTime );
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SaveToDateTimeTestCaseNullCheck()
        {
            StringEx.SaveToDateTime( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SaveToDateTimeTestCaseNullCheck1()
        {
            "".SaveToDateTime( null, DateTimeStyles.AdjustToUniversal );
        }
    }
}