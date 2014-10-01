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
        public void TruncateTestCase()
        {
            var actual = "testtest".Truncate( 7 );
            Assert.AreEqual( "test...", actual );
        }

        [Test]
        public void TruncateTestCase1()
        {
            var actual = "testtest".Truncate(7, "_-_");
            Assert.AreEqual("test_-_", actual);
        }

        [Test]
        public void TruncateTestCase2()
        {
            var actual = "abc".Truncate(7, "_-_");
            Assert.AreEqual("abc", actual);
        }

        [Test]
        public void TruncateTestCase3()
        {
            var actual = String.Empty.Truncate(7, "_-_");
            Assert.AreEqual(String.Empty, actual);
        }

        [Test]
        public void TruncateTestCase4()
        {
            String value = null;
            var actual = value.Truncate(7, "_-_");
            Assert.AreEqual(value, actual);
        }
    }
}