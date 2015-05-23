#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExecutionResultTest
    {
        [Test]
        public void CtorTestCase()
        {
            var target = new ExecutionResult<String>();
            Assert.IsNull( target.Exception );
            Assert.IsNull( target.Result );
        }

        [Test]
        public void ExceptionTestCase()
        {
            var target = new ExecutionResult<String>();
            var expected = new NotImplementedException();
            target.Exception = expected;

            Assert.AreSame( expected, target.Exception );
        }

        [Test]
        public void ResultTestCase()
        {
            var target = new ExecutionResult<String>();
            var expected = RandomValueEx.GetRandomString();
            target.Result = expected;

            Assert.AreEqual( expected, target.Result );
        }
    }
}