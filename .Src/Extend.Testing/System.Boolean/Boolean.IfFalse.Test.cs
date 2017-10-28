#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class BooleanExTest
    {
        [Fact]
        public void IfFalseTest()
        {
            var actual = String.Empty;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            false.IfFalse( () => actual = "0", () => actual = "1" );
            Assert.Equal( "0", actual );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            true.IfFalse( () => actual = "0", () => actual = "1" );
            Assert.Equal( "1", actual );
        }

        [Fact]
        public void IfFalseTest1()
        {
            var actual = String.Empty;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            false.IfFalse( "test", x => actual = x + "0", x => actual = x + "1" );
            Assert.Equal( "test0", actual );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            true.IfFalse( "test", x => actual = x + "0", x => actual = x + "1" );
            Assert.Equal( "test1", actual );
        }

        [Fact]
        public void IfFalseTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => false.IfFalse( "", null, x => Assert.True( false, "This should not happen." ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IfFalseTest2()
        {
            var actual = String.Empty;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            false.IfFalse( "test", "P2", ( x, y ) => actual = x + y + "0", ( x, y ) => actual = x + y + "1" );
            Assert.Equal( "testP20", actual );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            true.IfFalse( "test", "P2", ( x, y ) => actual = x + y + "0", ( x, y ) => actual = x + y + "1" );
            Assert.Equal( "testP21", actual );
        }

        [Fact]
        public void IfFalseTest2NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => false.IfFalse( "", "", null, ( x, y ) => Assert.True( false, "This should not happen." ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IfFalseTest3()
        {
            var actual = String.Empty;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            false.IfFalse( "test",
                           "P2",
                           "P3",
                           ( x, y, z ) => actual = x + y + z + "0",
                           ( x, y, z ) => actual = x + y + z + "1" );
            Assert.Equal( "testP2P30", actual );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            true.IfFalse( "test",
                          "P2",
                          "P3",
                          ( x, y, z ) => actual = x + y + z + "0",
                          ( x, y, z ) => actual = x + y + z + "1" );
            Assert.Equal( "testP2P31", actual );
        }

        [Fact]
        public void IfFalseTest3NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => false.IfFalse( "", "", "", null, ( x, y, z ) => Assert.True( false, "This should not happen." ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IfFalseTest4()
        {
            var actual = String.Empty;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            false.IfFalse( "test",
                           "P2",
                           "P3",
                           "P4",
                           ( x, y, z, a ) => actual = x + y + z + a + "0",
                           ( x, y, z, a ) => actual = x + y + z + a + "1" );
            Assert.Equal( "testP2P3P40", actual );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            true.IfFalse( "test",
                          "P2",
                          "P3",
                          "P4",
                          ( x, y, z, a ) => actual = x + y + z + a + "0",
                          ( x, y, z, a ) => actual = x + y + z + a + "1" );
            Assert.Equal( "testP2P3P41", actual );
        }

        [Fact]
        public void IfFalseTest4NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => false.IfFalse( "", "", "", "", null, ( x, y, z, a ) => Assert.True( false, "This should not happen." ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IfFalseTestNullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => false.IfFalse( null, () => Assert.True( false, "This should not happen." ) );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}