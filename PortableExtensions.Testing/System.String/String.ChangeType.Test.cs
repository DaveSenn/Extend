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
        [Test]
        public void ChangeTypeTestCase()
        {
            var actual = "100".ChangeType( typeof ( Int32 ) );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTestCase1()
        {
            var actual = "100".ChangeType( typeof ( Int32 ), CultureInfo.InvariantCulture );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ChangeTypeTestCase1NullCkeck()
        {
            var actual = "100".ChangeType( null, CultureInfo.InvariantCulture );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ChangeTypeTestCaseNullCkeck()
        {
            var actual = "100".ChangeType( null );
        }
    }
}