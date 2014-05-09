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
        public void ToCharTestCase()
        {
            var value = 'a';
            var actual = value.ToString().ToChar();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharTestCaseNullCheck()
        {
            StringEx.ToChar( null );
        }

        [TestCase]
        public void ToCharTestCase1()
        {
            var value = 'a';
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToChar( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharTestCase1NullCheck()
        {
            StringEx.ToChar( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharTestCase1NullCheck1()
        {
            "".ToChar( null );
        }
    }
}