#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ComparableTExTest
    {
        [Fact]
        public void BetweenTest()
        {
            var value = 100;
            var min = 50;
            var max = 300;

            var actual = value.Between( min, max );
            Assert.True( actual );

            value = 100;
            min = 50;
            max = 100;

            actual = value.Between( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenTest1()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenTest3()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenTest4()
        {
            const Int32 value = 4;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.Between( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetweenTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Between( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetweenTestNullCheck2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Between( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}