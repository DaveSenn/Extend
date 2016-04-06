#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToDateTimeTest()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.CurrentCulture ) as Object;
            var actual = value.ToDateTime();

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void ToDateTimeTest1()
        {
            var expected = DateTime.Now;
            var value = expected.ToString( CultureInfo.InvariantCulture ) as Object;
            var actual = value.ToDateTime( CultureInfo.InvariantCulture );

            Assert.AreEqual( expected.Year, actual.Year );
            Assert.AreEqual( expected.Month, actual.Month );
            Assert.AreEqual( expected.Day, actual.Day );
            Assert.AreEqual( expected.Hour, actual.Hour );
            Assert.AreEqual( expected.Minute, actual.Minute );
            Assert.AreEqual( expected.Second, actual.Second );
        }

        [Test]
        public void ToDateTimeTest1NullCheck()
        {
            Action test = () => ObjectEx.ToDateTime( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeTest1NullCheck1()
        {
            var dateTime = DateTime.Now.ToString( CultureInfo.InvariantCulture ) as Object;
            Action test = () => dateTime.ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeTestNullCheck()
        {
            Action test = () => ObjectEx.ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}