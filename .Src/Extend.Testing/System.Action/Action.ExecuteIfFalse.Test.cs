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
        public void ExecuteIfFalseTestCase()
        {
            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, null, false, false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, () => trueActionExecuted = true, false, false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, () => trueActionExecuted = true, true, false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, null, true, false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( null, null, true, false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
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
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                x => trueActionExecuted = x == parameter,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                x => trueActionExecuted = x == parameter,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                null,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( null, parameter, null, true, false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase1NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfFalse( null, RandomValueEx.GetRandomString(), null, false, false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( null,
                                     parameter1,
                                     parameter2,
                                     null,
                                     true,
                                     false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase2NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfFalse( null,
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     null,
                                     false,
                                     false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( null,
                                     parameter1,
                                     parameter2,
                                     parameter3,
                                     null,
                                     true,
                                     false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase3NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfFalse( null,
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     null,
                                     false,
                                     false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            var trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsTrue( trueActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfFalse( null,
                                     parameter1,
                                     parameter2,
                                     parameter3,
                                     parameter4,
                                     null,
                                     true,
                                     false );

            Assert.IsFalse( falseActionExecuted );
            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase4NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfFalse( null,
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     RandomValueEx.GetRandomString(),
                                     null,
                                     false,
                                     false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase5()
        {
            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, false, false );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, false, false );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, true, false );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse( () => falseActionExecuted = true, true, false );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action action = null;
            action.ExecuteIfFalse( true, false );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase5NullCheck()
        {
            Action action = null;
            Action test = () => action.ExecuteIfFalse( false, false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase6()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                x => falseActionExecuted = x == parameter,
                parameter,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String> action = null;
            action.ExecuteIfFalse( parameter, true, false );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase6NullCheck()
        {
            Action<String> action = null;
            Action test = () => action.ExecuteIfFalse( RandomValueEx.GetRandomString(), false, false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String> action = null;
            action.ExecuteIfFalse( parameter1, parameter2, true, false );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase7NullCheck()
        {
            Action<String, String> action = null;
            Action test = () => action.ExecuteIfFalse( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), null, false, false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String, String> action = null;
            action.ExecuteIfFalse( parameter1, parameter2, parameter3, true, false );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase8NullCheck()
        {
            Action<String, String, String> action = null;
            Action test = () => action.ExecuteIfFalse( RandomValueEx.GetRandomString(),
                                   RandomValueEx.GetRandomString(),
                                   RandomValueEx.GetRandomString(),
                                   null,
                                   false,
                                   false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCase9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                false );

            Assert.IsTrue( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfFalse(
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                false );

            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            Action<String, String, String, String> action = null;
            action.ExecuteIfFalse( parameter1, parameter2, parameter3, parameter4, true, false );

            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfFalseTestCase9NullCheck()
        {
            Action<String, String, String, String> action = null;
            Action test = () => action.ExecuteIfFalse( RandomValueEx.GetRandomString(),
                                   RandomValueEx.GetRandomString(),
                                   RandomValueEx.GetRandomString(),
                                   RandomValueEx.GetRandomString(),
                                   null,
                                   false,
                                   false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfFalseTestCaseNullCheck()
        {
            Action test = () => ActionEx.ExecuteIfFalse( null, null, false, false );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}