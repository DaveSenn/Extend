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
        public void ToDoubleTestCase()
        {
            var value = 1.2;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToDouble();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDoubleTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var value = 1232.22312;
            var actual = value.ToString( culture )
                              .ToDouble( culture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDoubleTestCase1NullCheck()
        {
            Action test = () => StringEx.ToDouble( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDoubleTestCase1NullCheck1()
        {
            Action test = () => "".ToDouble( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDoubleTestCaseNullCheck()
        {
            Action test = () => StringEx.ToDouble( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}