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
        public void ToDoubleTestCase()
        {
            var expected = 100.12;
            var value = expected.ToString();
            var actual = ObjectEx.ToDouble( value );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCaseNullCheck()
        {
            ObjectEx.ToDouble( null );
        }

        [TestCase]
        public void ToDoubleTestCase1()
        {
            var expected = 100.12;
            var value = expected.ToString( CultureInfo.InvariantCulture );
            var actual = ObjectEx.ToDouble( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCase1NullCheck()
        {
            ObjectEx.ToDouble( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCase1NullCheck1()
        {
            ObjectEx.ToDouble( "false", null );
        }
    }
}