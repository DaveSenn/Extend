#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void SplitLinesTest()
        {
            const String value = "test";

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.Single( actual );
            Assert.Equal( value, actual[0] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.Single( actual );
            Assert.Equal( value, actual[0] );
        }

        [Fact]
        public void SplitLinesTest1()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.Equal( 2, actual.Length );
            Assert.Equal( "test", actual[0] );
            Assert.Equal( "test", actual[1] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.Equal( 4, actual.Length );
            Assert.Equal( "test", actual[0] );
            Assert.Equal( "test", actual[1] );
            Assert.Equal( String.Empty, actual[2] );
            Assert.Equal( String.Empty, actual[3] );
        }

        [Fact]
        public void SplitLinesTest2()
        {
            const String value = "test";

            var actual = value.SplitLines();
            Assert.Single( actual );
            Assert.Equal( value, actual[0] );
        }

        [Fact]
        public void SplitLinesTest2NullCheck()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.SplitLines();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SplitLinesTest3()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines();
            Assert.Equal( 2, actual.Length );
            Assert.Equal( "test", actual[0] );
            Assert.Equal( "test", actual[1] );
        }

        [Fact]
        public void SplitLinesTestNullCheck()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.SplitLines( StringSplitOptions.RemoveEmptyEntries );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SplitLinesTestNullCheck1()
        {
            String value = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => value.SplitLines( StringSplitOptions.None );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}