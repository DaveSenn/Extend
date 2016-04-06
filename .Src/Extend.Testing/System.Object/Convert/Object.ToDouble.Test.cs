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
        public void ToDoubleTest()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = ObjectEx.ToDouble( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToDoubleTest1()
        {
            const Double expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = ObjectEx.ToDouble( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToDoubleTest1NullCheck()
        {
            Action test = () => ObjectEx.ToDouble( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDoubleTest1NullCheck1()
        {
            Action test = () => ObjectEx.ToDouble( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDoubleTestNullCheck()
        {
            Action test = () => ObjectEx.ToDouble( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}