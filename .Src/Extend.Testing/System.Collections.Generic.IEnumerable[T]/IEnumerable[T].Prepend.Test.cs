#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void PrependArgumentNullExceptionTest()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Prepend( "d" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PrependTest()
        {
            var list = new List<String> { "a", "b", "c" };
            var actual = list.Prepend( "d" );

            list.Should()
                .HaveCount( 3 );
            // ReSharper disable once PossibleMultipleEnumeration
            actual.Should()
                  .Contain( "d" );
            // ReSharper disable once PossibleMultipleEnumeration
            actual.ElementAt( 0 )
                  .Should()
                  .Be( "d" );
        }
    }
}