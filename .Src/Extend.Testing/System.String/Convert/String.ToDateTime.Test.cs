#region Usings

using System;
using System.Globalization;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToDateTimeInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDateTime();

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDateTimeNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeOtherCultureTest()
        {
            var culture = CultureInfo.CurrentCulture;
            //Thread.CurrentThread.CurrentCulture = new CultureInfo( "de-CH" );
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo( "de-CH" );
            CultureInfo.CurrentCulture = new CultureInfo("de-CH");
            CultureInfo.CurrentUICulture = new CultureInfo("de-CH");

            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDateTime();

            actual
                .Should()
                .BeCloseTo( value, 999 );

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        [Test]
        public void ToDateTimeOverloadFormatNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => DateTime.Now.ToString( CultureInfo.InvariantCulture )
                                        .ToDateTime( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeOverloadInvalidFormatTest()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "invalidFormat".ToDateTime( CultureInfo.CurrentCulture );

            test.ShouldThrow<FormatException>();
        }

        [Test]
        public void ToDateTimeOverloadNullTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToDateTime( null, CultureInfo.CurrentCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTimeOverloadOtherCultureTest()
        {
            var culture = new CultureInfo( "de-CH" );

            var value = DateTime.Now;
            var actual = value.ToString( culture )
                              .ToDateTime( culture );

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }

        [Test]
        public void ToDateTimeOverloadTest()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDateTime( CultureInfo.CurrentCulture );

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }

        [Test]
        public void ToDateTimeTest()
        {
            var value = DateTime.Now;
            var actual = value.ToString( CultureInfo.CurrentCulture )
                              .ToDateTime();

            actual
                .Should()
                .BeCloseTo( value, 999 );
        }
    }
}