#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class ExecutionResultTest
    {
        [TestCase]
        public void ExceptionTestCase()
        {
            var target = new ExecutionResult<String>();
            var expected = new NotImplementedException();
            target.Exception = expected;

            Assert.AreSame( expected, target.Exception );
        }

        [TestCase]
        public void ResultTestCase()
        {
            var target = new ExecutionResult<String>();
            var expected = RandomValueEx.GetRandomString();
            target.Result = expected;

            Assert.AreEqual( expected, target.Result );
        }
    }
}