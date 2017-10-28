#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void RangeToTest()
        {
            const Int32 start = 0;
            const Int32 end = 200;

            var expected = new List<Int32>();
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
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 200.RangeTo( 100 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}