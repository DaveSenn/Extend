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
        public void WithoutIndexArgumentNullExceptionTest()
        {
            List<IIndexedItem<String>> list = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => list.WithoutIndex();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WithoutIndexTest()
        {
            var list = new List<IIndexedItem<String>>
            {
                new IndexedItem<String>( 0, "a" ),
                new IndexedItem<String>( 1, "b" ),
                new IndexedItem<String>( 2, "c" ),
                new IndexedItem<String>( 3, "d" )
            };

            var actual = list.WithoutIndex()
                             .ToList();
            actual.Should()
                  .HaveCount( 4 );
            actual.Should()
                  .ContainInOrder( "a", "b", "c", "d" );
        }
    }
}