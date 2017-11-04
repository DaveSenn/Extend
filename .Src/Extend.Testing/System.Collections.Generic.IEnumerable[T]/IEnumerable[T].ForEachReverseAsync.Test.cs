#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public async Task ForEachReverseAsyncActionNullTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var enumerable = new List<Int32> { 1 };
            Func<Int32, Task> action = null;

            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                // ReSharper disable once PossibleNullReferenceException
                await enumerable.ForEachReverseAsync( async x => await action( x ) );
            }
            catch ( Exception ex )
            {
                ex.Should()
                  .BeOfType<NullReferenceException>();
                return;
            }

            false.Should()
                 .BeTrue( "This code should not get executed => exception was not thrown" );
        }

        [Fact]
        public void ForEachReverseAsyncCollectionNullTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            List<Int32> enumerable = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Func<Task> test = async () => await enumerable.ForEachReverseAsync( async x => await Task.FromResult( x ) );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task ForEachReverseAsyncEmptyCollectionTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var enumerable = new List<Int32>();
            var newValues = new List<Int32>();

            var actual = await enumerable.ForEachReverseAsync( async x => newValues.Add( await Task.FromResult( x ) ) );
            actual.Should()
                  .BeSameAs( enumerable );
            newValues.Should()
                     .HaveCount( 0 );
        }

        [Fact]
        public async Task ForEachReverseAsyncTest()
        {
            var enumerable = new List<Int32> { 1, 2, 3, 4 };
            var newValues = new List<Int32>();

            var actual = await enumerable.ForEachReverseAsync( async x => newValues.Add( await Task.FromResult( x ) ) );
            actual.Should()
                  .BeSameAs( enumerable );
            newValues.Should()
                     .HaveCount( 4 );
            newValues.Should()
                     .ContainInOrder( 4, 3, 2, 1 );
        }
    }
}