#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ActionExTest
    {
        [Test]
        public void ExecuteIfAnyFalseTest()
        {
            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => { },
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
                () => { },
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => { },
                () => { },
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest1()
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
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest1NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyFalse( null, RandomValueEx.GetRandomString(), null, false, true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest2()
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
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest2NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyFalse( null,
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            null,
                                                            false,
                                                            true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest3()
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
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
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
        public void ExecuteIfAnyFalseTest3NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyFalse( null,
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            null,
                                                            false,
                                                            true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3, p4 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
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
                ( p1, p2, p3, p4 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
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
        public void ExecuteIfAnyFalseTest4NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyFalse( null,
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            null,
                                                            false,
                                                            true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest5()
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
            Action action = () => { };
            falseActionExecuted = false;
            action.ExecuteIfAnyFalse( true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest5NullCheck()
        {
            Action action = null;
            Action test = () => action.ExecuteIfAnyFalse( false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest6()
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
            Action<String> action = x => { };
            action.ExecuteIfAnyFalse( parameter, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest6NullCheck()
        {
            Action<String> action = null;
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest7()
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
            Action<String, String> action = ( x, y ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest7NullCheck()
        {
            Action<String, String> action = null;
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), false, true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest8()
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
            Action<String, String, String> action = ( x, y, z ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest8NullCheck()
        {
            Action<String, String, String> action = null;
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          false,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTest9()
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
            Action<String, String, String, String> action = ( x, y, z, a ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, parameter4, true, true );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyFalseTest9NullCheck()
        {
            Action<String, String, String, String> action = null;
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          false,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyFalseTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyFalse( null, null, false, true );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}