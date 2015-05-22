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
        public void ExecuteIfAnyFalseTestCase()
        {
            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                null,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => trueActionExecuted = true,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => trueActionExecuted = true,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                null,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase1()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                p1 => trueActionExecuted = p1 == parameter,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                p1 => trueActionExecuted = p1 == parameter,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                null,
                parameter,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase1NullCheck()
        {
            ActionEx.ExecuteIfAnyFalse( null, RandomValueEx.GetRandomString(), null, false, true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                null,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase2NullCheck()
        {
            ActionEx.ExecuteIfAnyFalse( null,
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        null,
                                        false,
                                        true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                null,
                parameter1,
                parameter2,
                parameter3,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase3NullCheck()
        {
            ActionEx.ExecuteIfAnyFalse( null,
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        null,
                                        false,
                                        true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                null,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase4NullCheck()
        {
            ActionEx.ExecuteIfAnyFalse( null,
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        RandomValueEx.GetRandomString(),
                                        null,
                                        false,
                                        true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase5()
        {
            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action action = null;
            falseActionExecuted = false;
            action.ExecuteIfAnyFalse( true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase5NullCheck()
        {
            Action action = null;
            action.ExecuteIfAnyFalse( false, true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase6()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String> action = null;
            action.ExecuteIfAnyFalse( parameter, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase6NullCheck()
        {
            Action<String> action = null;
            action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), false, true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String> action = null;
            action.ExecuteIfAnyFalse( parameter1, parameter2, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase7NullCheck()
        {
            Action<String, String> action = null;
            action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), false, true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String, String> action = null;
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase8NullCheck()
        {
            Action<String, String, String> action = null;
            action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                      RandomValueEx.GetRandomString(),
                                      RandomValueEx.GetRandomString(),
                                      false,
                                      true );
        }

        [Test]
        public void ExecuteIfAnyFalseTestCase9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1$
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                true );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String, String, String> action = null;
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, parameter4, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCase9NullCheck()
        {
            Action<String, String, String, String> action = null;
            action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                      RandomValueEx.GetRandomString(),
                                      RandomValueEx.GetRandomString(),
                                      RandomValueEx.GetRandomString(),
                                      false,
                                      true );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ExecuteIfAnyFalseTestCaseNullCheck()
        {
            ActionEx.ExecuteIfAnyFalse( null, null, false, true );
        }
    }
}