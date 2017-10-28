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
        public void NotAnyTest()
        {
            var list = new List<String>();
            Assert.True( list.NotAny() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.False( list.NotAny() );
        }

        [Fact]
        public void NotAnyTest1()
        {
            var list = new List<String>();
            Assert.True( list.NotAny( x => true ) );
            Assert.True( list.NotAny( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.False( list.NotAny( x => true ) );
            Assert.True( list.NotAny( x => false ) );
        }

        [Fact]
        public void NotAnyTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.NotAny( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void NotAnyTest1NullCheck1()
        {
            Func<Object, Boolean> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().NotAny( func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void NotAnyTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.NotAny();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}