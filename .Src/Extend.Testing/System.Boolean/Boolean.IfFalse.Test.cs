#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class BooleanExTest
    {
        [Test]
        public void IfFalseTest()
        {
            var actual = String.Empty;

            false.IfFalse( () => actual = "0", () => actual = "1" );
            Assert.AreEqual( "0", actual );

            true.IfFalse( () => actual = "0", () => actual = "1" );
            Assert.AreEqual( "1", actual );
        }

        [Test]
        public void IfFalseTest1()
        {
            var actual = String.Empty;

            false.IfFalse( "test", x => actual = x + "0", x => actual = x + "1" );
            Assert.AreEqual( "test0", actual );

            true.IfFalse( "test", x => actual = x + "0", x => actual = x + "1" );
            Assert.AreEqual( "test1", actual );
        }

        [Test]
        public void IfFalseTest1NullCheck()
        {
            Action test = () => false.IfFalse( "", null, x => Assert.Fail() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IfFalseTest2()
        {
            var actual = String.Empty;

            false.IfFalse( "test", "P2", ( x, y ) => actual = x + y + "0", ( x, y ) => actual = x + y + "1" );
            Assert.AreEqual( "testP20", actual );

            true.IfFalse( "test", "P2", ( x, y ) => actual = x + y + "0", ( x, y ) => actual = x + y + "1" );
            Assert.AreEqual( "testP21", actual );
        }

        [Test]
        public void IfFalseTest2NullCheck()
        {
            Action test = () => false.IfFalse( "", "", null, ( x, y ) => Assert.Fail() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IfFalseTest3()
        {
            var actual = String.Empty;

            false.IfFalse( "test",
                           "P2",
                           "P3",
                           ( x, y, z ) => actual = x + y + z + "0",
                           ( x, y, z ) => actual = x + y + z + "1" );
            Assert.AreEqual( "testP2P30", actual );

            true.IfFalse( "test",
                          "P2",
                          "P3",
                          ( x, y, z ) => actual = x + y + z + "0",
                          ( x, y, z ) => actual = x + y + z + "1" );
            Assert.AreEqual( "testP2P31", actual );
        }

        [Test]
        public void IfFalseTest3NullCheck()
        {
            Action test = () => false.IfFalse( "", "", "", null, ( x, y, z ) => Assert.Fail() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IfFalseTest4()
        {
            var actual = String.Empty;

            false.IfFalse( "test",
                           "P2",
                           "P3",
                           "P4",
                           ( x, y, z, a ) => actual = x + y + z + a + "0",
                           ( x, y, z, a ) => actual = x + y + z + a + "1" );
            Assert.AreEqual( "testP2P3P40", actual );

            true.IfFalse( "test",
                          "P2",
                          "P3",
                          "P4",
                          ( x, y, z, a ) => actual = x + y + z + a + "0",
                          ( x, y, z, a ) => actual = x + y + z + a + "1" );
            Assert.AreEqual( "testP2P3P41", actual );
        }

        [Test]
        public void IfFalseTest4NullCheck()
        {
            Action test = () => false.IfFalse( "", "", "", "", null, ( x, y, z, a ) => Assert.Fail() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IfFalseTestNullCheck()
        {
            Action test = () => false.IfFalse( null, Assert.Fail );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}