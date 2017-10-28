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
        public void RemoveRangeTest()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.Equal( values.Count, list.Count );

            var result = list.RemoveRange( values.ToArray() );
            Assert.Empty( list );
            Assert.Same( list, result );
        }

        [Fact]
        public void RemoveRangeTest1()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.Equal( values.Count, list.Count );

            var result = list.RemoveRange( values );
            Assert.Empty( list );
            Assert.Same( list, result );
        }

        [Fact]
        public void RemoveRangeTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.RemoveRange( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.RemoveRange( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveRangeTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}