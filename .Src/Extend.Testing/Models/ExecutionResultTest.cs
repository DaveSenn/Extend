#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExecutionResultTest
    {
        [Test]
        public void CtorTest()
        {
            var target = new ExecutionResult<String>();

            target.Exception.Should()
                  .BeNull();
            target.Result.Should()
                  .BeNull();
        }

        [Test]
        public void ExceptionTest()
        {
            var target = new ExecutionResult<String>();
            var expected = new NotImplementedException();
            target.Exception = expected;

            target.Exception.Should()
                  .BeSameAs( expected );
        }

        [Test]
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