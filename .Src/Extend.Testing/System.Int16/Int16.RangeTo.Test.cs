#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int16ExTest
    {
        [Fact]
        public void RangeToTest()
        {
            const Int16 start = 0;
            const Int16 end = 200;

            var expected = new List<Int16>();
            for ( var i = start; i <= end; i++ )
                expected.Add( i );

            var actual = start.RangeTo( end );
            Assert.Equal( 0, actual.First() );
            Assert.Equal( 200, actual.Last() );
            Assert.Equal( expected.Count, actual.Count );

            for ( var i = 0; i < expected.Count; i++ )
                Assert.Equal( expected[i], actual[i] );
        }

        [Fact]
        public void RangeToTestArgumentException()
        {
            const Int16 start = 100;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => start.RangeTo( 50 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}