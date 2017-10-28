#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CollectionTExTest
    {
        [Fact]
        public void RemoveRangeIfTest()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.Equal( values.Count, list.Count );

            var result = list.RemoveRangeIf( x => false, values.ToArray() );
            Assert.Equal( values.Count, list.Count );
            Assert.Same( list, result );

            list.RemoveRangeIf( x => true, values.ToArray() );
            Assert.Empty( list );
        }

        [Fact]
        public void RemoveRangeIfTest1()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.Equal( values.Count, list.Count );

            var result = list.RemoveRangeIf( x => false, values );
            Assert.Equal( values.Count, list.Count );
            Assert.Same( list, result );

            list.RemoveRangeIf( x => true, values );
            Assert.Empty( list );
        }

        [Fact]
        public void RemoveRangeIfTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRangeIf( x => false, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeIfTest1NullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRangeIf( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeIfTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.RemoveRangeIf( null, x => false, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeIfTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRangeIf( x => false, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeIfTestNullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRangeIf( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeTestIfCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.RemoveRangeIf( null, x => false, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}