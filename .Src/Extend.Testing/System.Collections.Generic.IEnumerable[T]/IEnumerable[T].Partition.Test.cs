#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void PartitionArgumentNullExceptionTest()
        {
            List<String> target = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.Partition( 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void PartitionInvalidSizeTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new List<String>();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.Partition( -1 );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void PartitionNoItemsTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var target = new List<String>();
            var actual = target.Partition( 1 )
                               .ToList();

            actual.Should()
                  .HaveCount( 0 );
        }

        [Test]
        public void PartitionTest()
        {
            var target = new List<String> { "a", "b", "c", "d", "e" };
            var actual = target.Partition( 3 )
                               .ToList();

            actual.Should()
                  .HaveCount( 2 );
            actual[0].Should()
                     .HaveCount( 3 );
            actual[0].ElementAt( 0 )
                     .Should()
                     .Be( "a" );
            actual[0].ElementAt( 1 )
                     .Should()
                     .Be( "b" );
            actual[0].ElementAt( 2 )
                     .Should()
                     .Be( "c" );
            actual[1].Should()
                     .HaveCount( 2 );
            actual[1].ElementAt( 0 )
                     .Should()
                     .Be( "d" );
            actual[1].ElementAt( 1 )
                     .Should()
                     .Be( "e" );
        }

        [Test]
        public void PartitionTest1()
        {
            var target = new List<String> { "a", "b", "c" };
            var actual = target.Partition( 3 )
                               .ToList();

            actual.Should()
                  .HaveCount( 1 );
            actual[0].Should()
                     .HaveCount( 3 );
            actual[0].ElementAt( 0 )
                     .Should()
                     .Be( "a" );
            actual[0].ElementAt( 1 )
                     .Should()
                     .Be( "b" );
            actual[0].ElementAt( 2 )
                     .Should()
                     .Be( "c" );
        }

        [Test]
        public void PartitionTest2()
        {
            var target = new List<String> { "a", "b", "c", "d", "e", "f" };
            var actual = target.Partition( 3 )
                               .ToList();

            actual.Should()
                  .HaveCount( 2 );
            actual[0].Should()
                     .HaveCount( 3 );
            actual[0].ElementAt( 0 )
                     .Should()
                     .Be( "a" );
            actual[0].ElementAt( 1 )
                     .Should()
                     .Be( "b" );
            actual[0].ElementAt( 2 )
                     .Should()
                     .Be( "c" );
            actual[1].Should()
                     .HaveCount( 3 );
            actual[1].ElementAt( 0 )
                     .Should()
                     .Be( "d" );
            actual[1].ElementAt( 1 )
                     .Should()
                     .Be( "e" );
            actual[1].ElementAt( 2 )
                     .Should()
                     .Be( "f" );
        }

        [Test]
        public void PartitionTest3()
        {
            var target = new List<String> { "a", "b", "c", "d", "e", "f" };
            var actual = target.Partition( 10 )
                               .ToList();

            actual.Should()
                  .HaveCount( 1 );
            actual[0].Should()
                     .HaveCount( 6 );
            actual[0].ElementAt( 0 )
                     .Should()
                     .Be( "a" );
            actual[0].ElementAt( 1 )
                     .Should()
                     .Be( "b" );
            actual[0].ElementAt( 2 )
                     .Should()
                     .Be( "c" );
            actual[0].ElementAt( 3 )
                     .Should()
                     .Be( "d" );
            actual[0].ElementAt( 4 )
                     .Should()
                     .Be( "e" );
            actual[0].ElementAt( 5 )
                     .Should()
                     .Be( "f" );
        }
    }
}