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
        public void ToBooleanTestCase()
        {
            var value = "false";
            Assert.IsFalse( ObjectEx.ToBoolean( value ) );

            value = "true";
            Assert.IsTrue( ObjectEx.ToBoolean( value ) );
        }

        [Test]
        public void ToBooleanTestCase1()
        {
            var value = "false";
            Assert.IsFalse( ObjectEx.ToBoolean( value, CultureInfo.InvariantCulture ) );

            value = "true";
            Assert.IsTrue( ObjectEx.ToBoolean( value, CultureInfo.InvariantCulture ) );
        }

        [Test]
        public void ToBooleanTestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTestCase1NullCheck1()
        {
            Action test = () => ObjectEx.ToBoolean( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}