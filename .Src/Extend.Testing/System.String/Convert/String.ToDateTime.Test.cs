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
        public void ToDateTimeTestCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToDateTime( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeTestCase1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeTestCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}