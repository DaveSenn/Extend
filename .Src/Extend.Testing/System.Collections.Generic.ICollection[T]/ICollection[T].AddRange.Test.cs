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
        public void AddRangeTest()
        {
            var c = new List<String>();

            var result = c.AddRange( "test0", "test1", "test2" );
            Assert.Equal( 3, c.Count );
            Assert.Same( c, result );
        }

        [Fact]
        public void AddRangeTest1()
        {
            var c = new List<String>();

            var result = CollectionTEx.AddRange( c, new List<String> { "test0", "test1", "test2" } );
            Assert.Equal( 3, c.Count );
            Assert.Same( c, result );
        }

        [Fact]
        public void AddRangeTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRange( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeTest1NullCheck1()
        {
            List<String> array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRange( new List<String>(), array );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRange( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddRangeTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRange( new List<String>(), null );

            test.ShouldThrow<ArgumentException>();
        }
    }
}