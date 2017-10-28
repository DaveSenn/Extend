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
        public void WithIndexArgumentNullExceptionTest()
        {
            List<String> list = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => list.WithIndex();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WithIndexTest()
        {
            var list = new List<String>
            {
                "a",
                "b",
                "c",
                "d"
            };
            var actual = list.WithIndex()
                             .ToList();

            actual.Should()
                  .HaveCount( 4 );
            actual[0]
                .Item.Should()
                .Be( "a" );
            actual[0]
                .Index.Should()
                .Be( 0 );
            actual[1]
                .Item.Should()
                .Be( "b" );
            actual[1]
                .Index.Should()
                .Be( 1 );
            actual[2]
                .Item.Should()
                .Be( "c" );
            actual[2]
                .Index.Should()
                .Be( 2 );
            actual[3]
                .Item.Should()
                .Be( "d" );
            actual[3]
                .Index.Should()
                .Be( 3 );
        }
    }
}