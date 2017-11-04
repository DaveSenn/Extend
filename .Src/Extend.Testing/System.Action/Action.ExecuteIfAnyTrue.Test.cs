#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ActionExTest
    {
        [Fact]
        public void ExecuteIfAnyTrueTest()
        {
            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                null,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                () => falseActionExecuted = true,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                () => falseActionExecuted = true,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest1()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                p1 => falseActionExecuted = p1 == parameter,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                p1 => falseActionExecuted = p1 == parameter,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyTrue( null, RandomValueEx.GetRandomString(), null, false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyTrue( null,
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           null,
                                                           false,
                                                           true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
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

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
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

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
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

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
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

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyTrue( null,
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           RandomValueEx.GetRandomString(),
                                                           null,
                                                           false,
                                                           true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1
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

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
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

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
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

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3, p4 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                false,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest4NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
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

        [Fact]
        public void ExecuteIfAnyTrueTest5()
        {
            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                () => trueActionExecuted = true,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action action = () => { };
            action.ExecuteIfAnyTrue( false, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest5NullCheck()
        {
            Action action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyTrue( false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest6()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                p1 => trueActionExecuted = p1 == parameter,
                parameter,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String> action = x => { };
            action.ExecuteIfAnyTrue( parameter, false, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest6NullCheck()
        {
            Action<String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String> action = ( x, y ) => { };
            action.ExecuteIfAnyTrue( parameter1, parameter2, false, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest7NullCheck()
        {
            Action<String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String, String> action = ( x, y, z ) => { };
            action.ExecuteIfAnyTrue( parameter1, parameter2, parameter3, false, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest8NullCheck()
        {
            Action<String, String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         false,
                                                         true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTest9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1
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

            Assert.True( trueActionExecuted );

            // Case 2
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

            Assert.True( trueActionExecuted );

            // Case 3
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

            Assert.False( trueActionExecuted );

            // Case 4
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

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String, String, String> action = ( x, y, z, a ) => { };
            action.ExecuteIfAnyTrue( parameter1, parameter2, parameter3, parameter4, false, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyTrueTest9NullCheck()
        {
            Action<String, String, String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyTrue( RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         RandomValueEx.GetRandomString(),
                                                         false,
                                                         true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyTrueTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyTrue( null, null, false, true );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}