#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void FormatFileExtensionTestCase()
        {
            var actual = "xml".FormatFileExtension();
            Assert.AreEqual( ".xml", actual );

            actual = ".xml".FormatFileExtension();
            Assert.AreEqual( ".xml", actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void FormatFileExtensionTestCaseNullCheck()
        {
            StringEx.FormatFileExtension( null );
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FormatFileExtensionTestCaseNullCheckArgumentException()
        {
            String.Empty.FormatFileExtension();
        }
    }
}