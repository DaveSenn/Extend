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
        public void ToDoubleTestCase()
        {
            var value = 1.2;
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToDouble();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCaseNullCheck()
        {
            StringEx.ToDouble( null );
        }

        [TestCase]
        public void ToDoubleTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var value = 1232.22312;
            var actual = value.ToString( culture ).ToDouble( culture );

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCase1NullCheck()
        {
            StringEx.ToDouble( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToDoubleTestCase1NullCheck1()
        {
            "".ToDouble( null );
        }
    }
}