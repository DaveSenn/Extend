#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class ExecutionResultTest
    {
        [Fact]
        public void CtorTest()
        {
            var target = new ExecutionResult<String>();

            target.Exception.Should()
                  .BeNull();
            target.Result.Should()
                  .BeNull();
        }

        [Fact]
        public void ExceptionTest()
        {
            var target = new ExecutionResult<String>();
            var expected = new NotImplementedException();
            target.Exception = expected;

            target.Exception.Should()
                  .BeSameAs( expected );
        }

        [Fact]
        public void ResultTest()
        {
            var target = new ExecutionResult<String>();
            var expected = RandomValueEx.GetRandomString();
            target.Result = expected;

            target.Result.Should()
                  .Be( expected );
        }
    }
}