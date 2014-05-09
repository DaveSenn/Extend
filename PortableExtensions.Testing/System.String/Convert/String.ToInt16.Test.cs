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
        public void ToInt16TestCase()
        {
            var value = RandomValueEx.GetRandomInt16();
            var actual = value.ToString().ToInt16();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToInt16TestCaseNullCheck()
        {
            StringEx.ToInt16( null );
        }

        [TestCase]
        public void ToInt16TestCase1()
        {
            var value = RandomValueEx.GetRandomInt16();
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToInt16( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToInt16TestCase1NullCheck()
        {
            StringEx.ToInt16( null, CultureInfo.InvariantCulture );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToInt16TestCase1NullCheck1()
        {
            "".ToInt16( null );
        }
    }
}