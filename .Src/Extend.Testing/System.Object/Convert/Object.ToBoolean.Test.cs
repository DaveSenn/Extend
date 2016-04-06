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
        public void ToBooleanTest()
        {
            var value = "false";
            Assert.IsFalse( ObjectEx.ToBoolean( value ) );

            value = "true";
            Assert.IsTrue( ObjectEx.ToBoolean( value ) );
        }

        [Test]
        public void ToBooleanTest1()
        {
            var value = "false";
            Assert.IsFalse( value.ToBoolean( CultureInfo.InvariantCulture ) );

            value = "true";
            Assert.IsTrue( value.ToBoolean( CultureInfo.InvariantCulture ) );
        }

        [Test]
        public void ToBooleanTest1NullCheck()
        {
            Action test = () => ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTest1NullCheck1()
        {
            Action test = () => "false".ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBooleanTestNullCheck()
        {
            Action test = () => ObjectEx.ToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}