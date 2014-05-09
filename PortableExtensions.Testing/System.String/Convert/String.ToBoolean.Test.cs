#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void ToBooleanTestCase()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString().ToBoolean();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCaseNullCheck()
        {
            StringEx.ToBoolean( null );
        }

        [TestCase]
        public void ToBooleanTestCase1()
        {
            var value = RandomValueEx.GetRandomBoolean();
            var actual = value.ToString().ToBoolean( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCase1NullCheck()
        {
            StringEx.ToBoolean( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToBooleanTestCase1NullCheck1()
        {
            "".ToBoolean( null );
        }
    }
}