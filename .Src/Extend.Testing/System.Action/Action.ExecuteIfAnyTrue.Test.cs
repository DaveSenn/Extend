﻿#region Usings

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
        public void ExecuteIfAnyTrueTestCase()
        {
            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                null,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                () => falseActionExecuted = true,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                () => falseActionExecuted = true,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsTrue( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                null,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase1()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                p1 => falseActionExecuted = p1 == parameter,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                p1 => falseActionExecuted = p1 == parameter,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsTrue( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                null,
                parameter,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase1NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyTrue( null, RandomValueEx.GetRandomString(), null, false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsTrue( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                null,
                parameter1,
                parameter2,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase2NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyTrue( null,
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           null,
                                                           false,
                                                           true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsTrue( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                null,
                parameter1,
                parameter2,
                parameter3,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase3NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyTrue( null,
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           null,
                                                           false,
                                                           true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 2
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsTrue( falseActionExecuted );

            //Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );

            //Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                null,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );
            Assert.IsFalse( falseActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase4NullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyTrue( null,
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
        public void ExecuteIfAnyTrueTestCase5()
        {
            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 5
            trueActionExecuted = false;
            Action action = null;
            action.ExecuteIfAnyTrue( false, false );

            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase5NullCheck()
        {
            Action action = null;
            Action test = () => action.ExecuteIfAnyTrue( false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase6()
        {
            var parameter = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 5
            trueActionExecuted = false;
            Action<String> action = null;
            action.ExecuteIfAnyTrue( parameter, false, false );

            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase6NullCheck()
        {
            Action<String> action = null;
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 5
            trueActionExecuted = false;
            Action<String, String> action = null;
            action.ExecuteIfAnyTrue( parameter1, parameter2, false, false );

            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase7NullCheck()
        {
            Action<String, String> action = null;
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 5
            trueActionExecuted = false;
            Action<String, String, String> action = null;
            action.ExecuteIfAnyTrue( parameter1, parameter2, parameter3, false, false );

            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase8NullCheck()
        {
            Action<String, String, String> action = null;
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         false,
                                                         true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            //Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                true );

            Assert.IsTrue( trueActionExecuted );

            //Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                false,
                false );

            Assert.IsFalse( trueActionExecuted );

            //Case 5
            trueActionExecuted = false;
            Action<String, String, String, String> action = null;
            action.ExecuteIfAnyTrue( parameter1, parameter2, parameter3, parameter4, false, false );

            Assert.IsFalse( trueActionExecuted );
        }

        [Test]
        public void ExecuteIfAnyTrueTestCase9NullCheck()
        {
            Action<String, String, String, String> action = null;
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         false,
                                                         true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExecuteIfAnyTrueTestCaseNullCheck()
        {
            Action test = () => ActionEx.ExecuteIfAnyTrue( null, null, false, true );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}