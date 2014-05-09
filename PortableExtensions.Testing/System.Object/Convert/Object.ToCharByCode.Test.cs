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
        public void ToCharByCodeTestCase()
        {
            var charValue = 'a';
            var value = charValue.ToString();
            var expected = Convert.ToChar( value );
            var actual = value.ToCharByCode();
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharByCodeTestCaseNullCheck()
        {
            ObjectEx.ToCharByCode( null );
        }

        [TestCase]
        public void ToCharByCodeTestCase1()
        {
            var charValue = 'a';
            var value = charValue.ToString();
            var expected = Convert.ToChar( value );
            var actual = value.ToCharByCode( CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharByCodeTestCase1NullCheck()
        {
            ObjectEx.ToCharByCode( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharByCodeTestCase1NullCheck1()
        {
            "false".ToCharByCode( null );
        }
    }
}