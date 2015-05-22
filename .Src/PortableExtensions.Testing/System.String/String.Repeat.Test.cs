#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void RepeatTestCase()
        {
            var actual = StringEx.Repeat( null, 10 );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void RepeatTestCase1()
        {
            var actual = "".Repeat( 10 );
            Assert.AreEqual( String.Empty, actual );

            actual = "a".Repeat( 10 );
            Assert.AreEqual( "aaaaaaaaaa", actual );
        }

        [Test]
        public void RepeatTestCase2()
        {
            var actual = "a".Repeat( 10 );
            Assert.AreEqual( "aaaaaaaaaa", actual );
        }

        [Test]
        public void RepeatTestCase3()
        {
            var actual = "test".Repeat( 2 );
            Assert.AreEqual( "testtest", actual );
        }
    }
}