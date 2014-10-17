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
        public void ToInt32TestCase ()
        {
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString().ToInt32();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToInt32TestCase1 ()
        {
            var value = RandomValueEx.GetRandomInt32();
            var actual = value.ToString( CultureInfo.InvariantCulture ).ToInt32( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToInt32TestCase1NullCheck ()
        {
            StringEx.ToInt32( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToInt32TestCase1NullCheck1 ()
        {
            "".ToInt32( null );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ToInt32TestCaseNullCheck ()
        {
            StringEx.ToInt32( null );
        }
    }
}