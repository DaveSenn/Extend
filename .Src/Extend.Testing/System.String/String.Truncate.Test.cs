#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TruncateTest()
        {
            var actual = "testtest".Truncate( 7 );
            Assert.AreEqual( "test...", actual );
        }

        [Test]
        public void TruncateTest1()
        {
            var actual = "testtest".Truncate( 7, "_-_" );
            Assert.AreEqual( "test_-_", actual );
        }

        [Test]
        public void TruncateTest2()
        {
            var actual = "abc".Truncate( 7, "_-_" );
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        public void TruncateTest3()
        {
            var actual = String.Empty.Truncate( 7, "_-_" );
            Assert.AreEqual( String.Empty, actual );
        }

        [Test]
        public void TruncateTest4()
        {
            String value = null;
            var actual = value.Truncate( 7, "_-_" );
            Assert.AreEqual( value, actual );
        }
    }
}