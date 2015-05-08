#region Usings

using System;
using System.IO;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void GetFileExtensionTestCase()
        {
            var fielName = "test.txt";
            var expected = Path.GetExtension( fielName );
            var actual = fielName.GetFileExtension();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetFileExtensionTestCaseNullCheck()
        {
            StringEx.GetFileExtension( null );
        }
    }
}