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
        public void ExecuteIfTrueTestCase()
        {
            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, null, true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 2
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, () => falseActionExecuted = true, true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, () => falseActionExecuted = true, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsTrue(falseActionExecuted);

            //Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(null, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);
        }

        [Test]
        public void ExecuteIfTrueTestCase1()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, null, true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 2
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter,
                x => falseActionExecuted = x == parameter, true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter,
                x => falseActionExecuted = x == parameter, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsTrue(falseActionExecuted);

            //Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(null, parameter, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase1NullCheck()
        {
            ActionEx.ExecuteIfTrue(null, RandomValueEx.GetRandomString(), null, true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                null,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 2
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                (p1, p2) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                (p1, p2) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsTrue(falseActionExecuted);

            //Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                null,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(null, parameter1, parameter2, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase2NullCheck()
        {
            ActionEx.ExecuteIfTrue(null, RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), null, true,
                true);
        }

        [Test]
        public void ExecuteIfTrueTestCase3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                null,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 2
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                (p1, p2, p3) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                (p1, p2, p3) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsTrue(falseActionExecuted);

            //Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                null,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(null, parameter1, parameter2, parameter3, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase3NullCheck()
        {
            ActionEx.ExecuteIfTrue(null, RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(),
                RandomValueEx.GetRandomString(), null, true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                null,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 2
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                (p1, p2, p3, p4) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true, true);

            Assert.IsTrue(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                (p1, p2, p3, p4) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsTrue(falseActionExecuted);

            //Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                null,
                true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);

            //Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(null, parameter1, parameter2, parameter3, parameter4, null, true, false);

            Assert.IsFalse(trueActionExecuted);
            Assert.IsFalse(falseActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase4NullCheck()
        {
            ActionEx.ExecuteIfTrue(null, RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(),
                RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), null, true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase5()
        {
            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(() => trueActionExecuted = true, true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 5
            trueActionExecuted = false;
            Action trueAction = null;
            trueAction.ExecuteIfTrue(true, false);

            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase5NullCheck()
        {
            Action trueAction = null;
            trueAction.ExecuteIfTrue(true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase6()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(x => trueActionExecuted = x == parameter, parameter, true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 5
            trueActionExecuted = false;
            Action<String> trueAction = null;
            trueAction.ExecuteIfTrue(parameter, true, false);

            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase6NullCheck()
        {
            Action<String> trueAction = null;
            trueAction.ExecuteIfTrue(RandomValueEx.GetRandomString(), true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1, parameter2,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 5
            trueActionExecuted = false;
            Action<String, String> trueAction = null;
            trueAction.ExecuteIfTrue(parameter1, parameter2, true, false);

            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase7NullCheck()
        {
            Action<String, String> trueAction = null;
            trueAction.ExecuteIfTrue(RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1, parameter2, parameter3,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 5
            trueActionExecuted = false;
            Action<String, String, String> trueAction = null;
            trueAction.ExecuteIfTrue(parameter1, parameter2, parameter3, true, false);

            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase8NullCheck()
        {
            Action<String, String, String> trueAction = null;
            trueAction.ExecuteIfTrue(RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(),
                RandomValueEx.GetRandomString(), true, true);
        }

        [Test]
        public void ExecuteIfTrueTestCase9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                true, true);

            Assert.IsTrue(trueActionExecuted);

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                (p1, p2, p3, p4) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1, parameter2, parameter3, parameter4,
                true, false);

            Assert.IsFalse(trueActionExecuted);

            //Case 5
            trueActionExecuted = false;
            Action<String, String, String, String> trueAction = null;
            trueAction.ExecuteIfTrue(parameter1, parameter2, parameter3, parameter4, true, false);

            Assert.IsFalse(trueActionExecuted);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCase9NullCheck()
        {
            Action<String, String, String, String> trueAction = null;
            trueAction.ExecuteIfTrue(RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(),
                RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), true, true);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ExecuteIfTrueTestCaseNullCheck()
        {
            ActionEx.ExecuteIfTrue(null, null, true, true);
        }
    }
}