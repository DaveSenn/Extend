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
        public void BetweenInclusiveTest()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 300;

            var actual = value.BetweenInclusive( min, max );
            Assert.True( actual );
        }

        [Fact]
        public void BetweenInclusiveTest1()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.True( actual );
        }

        [Fact]
        public void BetweenInclusiveTest2()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 99;

            var actual = value.BetweenInclusive( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenInclusiveTest3()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenInclusiveTest4()
        {
            const Int32 value = 2;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.False( actual );
        }

        [Fact]
        public void BetweenInclusiveTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.BetweenInclusive( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetweenInclusiveTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".BetweenInclusive( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BetweenInclusiveTestNullCheck2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".BetweenInclusive( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}