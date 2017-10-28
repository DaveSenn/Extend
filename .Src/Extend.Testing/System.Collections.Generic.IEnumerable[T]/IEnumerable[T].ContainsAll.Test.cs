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
        public void ContainsAllTest()
        {
            var list = new List<String> { "test", "test1" };

            Assert.True( list.ContainsAll( "test" ) );
            Assert.True( list.ContainsAll( "test", "test1" ) );
            Assert.False( list.ContainsAll( "test", "test1", "test2" ) );
        }

        [Fact]
        public void ContainsAllTest1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.True( list.ContainsAll( new List<String> { "test" } ) );
            Assert.True( list.ContainsAll( list ) );
            Assert.False( list.ContainsAll( new List<String> { "test", "test1", "test2" } ) );
        }

        [Fact]
        public void ContainsAllTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEnumerableTEx.ContainsAll( null, new List<String>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAllTest1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ContainsAll( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAllTestNullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ContainsAll( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAllTestNullCheck1()
        {
            Object[] array = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ContainsAll( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}