#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void ToHashSetCollectionNullTest()
        {
            List<Int32> collection = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => collection.ToHashSet();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ToHashSetEmptyCollectionTest()
        {
            var actual = new List<Int32>().ToHashSet();

            actual.Should()
                  .HaveCount( 0 );
        }

        [Fact]
        public void ToHashSetTest()
        {
            var collection = new List<Int32> { 1, 3, 5, 7 };
            var actual = collection.ToHashSet();

            actual.Should()
                  .HaveCount( 4 );
            actual.Should()
                  .ContainInOrder( new List<Int32> { 1, 3, 5, 7 } );
        }
    }
}