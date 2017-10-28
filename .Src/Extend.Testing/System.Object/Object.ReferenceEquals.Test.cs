#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ReferenceEqualsTest()
        {
            var list = new List<String>();
            var list1 = new List<String>();

            var actual = list.RefEquals( list );
            Assert.True( actual );

            actual = list.RefEquals( list1 );
            Assert.False( actual );
        }

        [Fact]
        public void ReferenceEqualsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ObjectEx.RefEquals( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReferenceEqualsTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".RefEquals( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}