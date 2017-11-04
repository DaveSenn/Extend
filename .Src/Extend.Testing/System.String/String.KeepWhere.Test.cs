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
        public void KeepWhereCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.KeepWhere( null, x => false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void KeepWhereTest()
        {
            var actual = "a1-b2.c3".KeepWhere( x => x.IsLetter() || x.IsNumber() );
            Assert.Equal( "a1b2c3", actual );
        }

        [Fact]
        public void KeepWhereTEstCaseNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".KeepWhere( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}