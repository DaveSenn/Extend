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
        public void AppendArgumentNullExceptionTest()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.Append( "d" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AppendTest()
        {
            var list = new List<String> { "a", "b", "c" };
            var actual = list.Append( "d" );

            list.Should()
                .HaveCount( 3 );
            // ReSharper disable once PossibleMultipleEnumeration
            actual.Should()
                  .Contain( "d" );
            // ReSharper disable once PossibleMultipleEnumeration
            actual.ElementAt( 3 )
                  .Should()
                  .Be( "d" );
        }
    }
}