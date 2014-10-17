#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ToBooleanTestCase ()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString().ToBoolean();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToBooleanTestCase1 ()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString().ToBoolean( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToBooleanTestCase1NullCheck ()
        {
            StringEx.ToBoolean( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToBooleanTestCase1NullCheck1 ()
        {
            "".ToBoolean( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToBooleanTestCaseNullCheck ()
        {
            StringEx.ToBoolean( null );
        }
    }
}