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
        public void ToInt64TestCase()
        {
            var value = (Int64) RandomValueEx.GetRandomInt32();
            var actual = value.ToString()
                              .ToInt64();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt64TestCase1()
        {
            var value = (Int64) RandomValueEx.GetRandomInt32();
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToInt64( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToInt64TestCase1NullCheck()
        {
            StringEx.ToInt64( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToInt64TestCase1NullCheck1()
        {
            "".ToInt64( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToInt64TestCaseNullCheck()
        {
            StringEx.ToInt64( null );
        }
    }
}