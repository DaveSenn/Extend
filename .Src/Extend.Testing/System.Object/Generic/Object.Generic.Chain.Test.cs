#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ChainTest()
        {
            var list = new List<String>();
            var actual = list.Chain( x => x.Add( "Test1" ) )
                             .Chain( x => x.Add( "Test2" ) )
                             .Chain( x => x.Add( "Test3" ) );

            Assert.Same( list, actual );
            Assert.Equal( 3, list.Count );
        }

        [Fact]
        public void ChainTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new List<String>().Chain( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}