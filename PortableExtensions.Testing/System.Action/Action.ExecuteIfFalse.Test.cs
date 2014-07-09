#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ActionExTest
    {
        [Test]
        public void ExecuteIfFalseTestCase()
        {
            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(() => falseActionExecuted = true, null, false, false);

            Assert.IsTrue(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(() => falseActionExecuted = true, () => trueActionExecuted = true, false, false);

            Assert.IsTrue(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(() => falseActionExecuted = true, () => trueActionExecuted = true, true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsTrue(trueActionExecuted);

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(() => falseActionExecuted = true, null, true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(null, null, true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfFalseTestCaseNullCheck()
        {
            ActionEx.ExecuteIfFalse(null, null, false, false);
        }

        [Test]
        public void ExecuteIfFalseTestCase1()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter, 
                parameter, 
                null, 
                false, false);

            Assert.IsTrue(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                x => trueActionExecuted = x == parameter,
                false, false);

            Assert.IsTrue(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                x => trueActionExecuted = x == parameter, 
                true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsTrue(trueActionExecuted);

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                null,
                true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(null, parameter, null, true, false);

            Assert.IsFalse(falseActionExecuted);
            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteIfFalseTestCase1NullCheck()
        {
            ActionEx.ExecuteIfFalse(null, RandomValueEx.GetRandomString(), null, false, false);
        }
    }
}