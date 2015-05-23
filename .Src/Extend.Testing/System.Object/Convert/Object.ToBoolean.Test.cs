#region Usings

using System;
using System.Globalization;
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToBooleanTestCase1NullCheck()
        {
            ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToBooleanTestCase1NullCheck1()
        {
            ObjectEx.ToBoolean( "false", null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToBooleanTestCaseNullCheck()
        {
            ObjectEx.ToBoolean( null );
        }
    }
}