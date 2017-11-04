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
        public void ContainsAnyTest()
        {
            var list = new List<String> { "test", "test1" };

            Assert.True( list.ContainsAny( "test" ) );
            Assert.True( list.ContainsAny( "test", "test1" ) );
            Assert.True( list.ContainsAny( "test", "test1", "test2" ) );
            Assert.False( list.ContainsAny( "asdasd" ) );
        }

        [Fact]
        public void ContainsAnyTest1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.True( list.ContainsAny( new List<String> { "test" } ) );
            Assert.True( list.ContainsAny( new List<String> { "test", "test1" } ) );
            Assert.True( list.ContainsAny( new List<String> { "test", "test1", "test2" } ) );
            Assert.False( list.ContainsAny( new List<String> { "asdasd" } ) );
        }

        [Fact]
        public void ContainsAnyTest1NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ContainsAny( null, new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyTest1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().ContainsAny( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyTestNullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ContainsAny( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyTestNullCheck1()
        {
            Object[] array = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().ContainsAny( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}