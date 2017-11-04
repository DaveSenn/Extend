#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void RemoveWhereTest()
        {
            var actual = "a1-b2.c3".RemoveWhere( x => x.IsNumber() );
            Assert.Equal( "a-b.c", actual );
        }

        [Fact]
        public void RemoveWhereTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.RemoveWhere( null, x => false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveWhereTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".RemoveWhere( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}