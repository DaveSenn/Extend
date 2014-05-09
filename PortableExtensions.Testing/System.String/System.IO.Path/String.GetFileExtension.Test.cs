#region Using

using System;
using System.IO;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void GetFileExtensionTestCase()
        {
            var fielName = "test.txt";
            var expected = Path.GetExtension( fielName );
            var actual = fielName.GetFileExtension();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetFileExtensionTestCaseNullCheck()
        {
            StringEx.GetFileExtension( null );
        }
    }
}