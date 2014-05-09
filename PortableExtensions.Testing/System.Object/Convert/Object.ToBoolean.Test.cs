#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void ToBooleanTestCase()
        {
            var value = "false";
            Assert.IsFalse( ObjectEx.ToBoolean( value ) );

            value = "true";
            Assert.IsTrue( ObjectEx.ToBoolean( value ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCaseNullCheck()
        {
            ObjectEx.ToBoolean( null );
        }

        [TestCase]
        public void ToBooleanTestCase1()
        {
            var value = "false";
            Assert.IsFalse( ObjectEx.ToBoolean( value, CultureInfo.InvariantCulture ) );

            value = "true";
            Assert.IsTrue( ObjectEx.ToBoolean( value, CultureInfo.InvariantCulture ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCase1NullCheck()
        {
            ObjectEx.ToBoolean( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCase1NullCheck1()
        {
            ObjectEx.ToBoolean( "false", null );
        }
    }
}