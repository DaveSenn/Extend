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
        public void AddRangeIfNotContains1TestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRangeIfNotContains( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeIfNotContains1TestNullCheck1()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIfNotContains( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeIfNotContainsTest()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.Equal( 3, c.Count );
            Assert.Same( c, result );

            c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.Equal( 3, c.Count );
        }

        [Fact]
        public void AddRangeIfNotContainsTest1()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( new List<String> { "test0", "test1", "test2" } );
            Assert.Equal( 3, c.Count );
            Assert.Same( c, result );

            c.AddRangeIfNotContains( new List<String> { "test0", "test1", "test2" } );
            Assert.Equal( 3, c.Count );
        }

        [Fact]
        public void AddRangeIfNotContainsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRangeIfNotContains( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeIfNotContainsTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIfNotContains( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}