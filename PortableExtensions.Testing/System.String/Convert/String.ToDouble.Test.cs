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
        public void ToDoubleTestCase ()
        {
            var value = 1.2;
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToDouble();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToDoubleTestCase1 ()
        {
            var culture = new CultureInfo( "en-US" );
            var value = 1232.22312;
            var actual = value.ToString( culture ).ToDouble( culture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDoubleTestCase1NullCheck ()
        {
            StringEx.ToDouble( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDoubleTestCase1NullCheck1 ()
        {
            "".ToDouble( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToDoubleTestCaseNullCheck ()
        {
            StringEx.ToDouble( null );
        }
    }
}