#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToDateTimeTest1()
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
        public void SaveToDateTimeTest2()
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
        public void SaveToDateTimeTest3()
        {
            var expected = DateTime.Now;
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDateTimeTest5()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SaveToDateTime();

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void SaveToDateTimeTest6()
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
        public void SaveToDateTimeTest7()
        {
            var expected = default(DateTime);
            var actual = "InvalidValue".SaveToDateTime( CultureInfo.InvariantCulture, DateTimeStyles.None );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToDateTimeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.SaveToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToDateTimeTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".SaveToDateTime( null, DateTimeStyles.AdjustToUniversal );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}