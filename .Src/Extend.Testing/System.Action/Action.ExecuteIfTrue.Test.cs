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
        public void ExecuteIfTrueTest()
        {
            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, null, true, true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, () => falseActionExecuted = true, true, true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, () => falseActionExecuted = true, true, false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, null, true, false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, null, true, false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest1()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, null, true, true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter,
                                    parameter,
                                    x => falseActionExecuted = x == parameter,
                                    true,
                                    true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter,
                                    parameter,
                                    x => falseActionExecuted = x == parameter,
                                    true,
                                    false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, null, true, false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, null, true, false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfTrue( null, RandomValueEx.GetRandomString(), null, true, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2, parameter1, parameter2, null, true, false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfTrue( null,
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        null,
                                                        true,
                                                        true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                null,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                                    parameter1,
                                    parameter2,
                                    parameter3,
                                    null,
                                    true,
                                    false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfTrue( null,
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        null,
                                                        true,
                                                        true );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void ExecuteIfTrueTest4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true,
                true );

            Assert.True( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 3
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                ( p1, p2, p3, p4 ) =>
                    falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.True( falseActionExecuted );

            // Case 4
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                null,
                true,
                false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );

            // Case 5
            trueActionExecuted = false;
            falseActionExecuted = false;
            ActionEx.ExecuteIfTrue( ( p1, p2, p3, p4 ) =>
                                        trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                                    parameter1,
                                    parameter2,
                                    parameter3,
                                    parameter4,
                                    null,
                                    true,
                                    false );

            Assert.False( trueActionExecuted );
            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest4NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfTrue( null,
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        RandomValueEx.GetRandomString(),
                                                        null,
                                                        true,
                                                        true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest5()
        {
            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, true, true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, true, true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, true, false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( () => trueActionExecuted = true, true, false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action trueAction = () => trueActionExecuted = true;
            trueAction.ExecuteIfTrue( true, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest5NullCheck()
        {
            Action trueAction = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => trueAction.ExecuteIfTrue( true, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest6()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, true, true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, true, true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, true, false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue( x => trueActionExecuted = x == parameter, parameter, true, false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String> trueAction = x => trueActionExecuted = x == parameter;
            trueAction.ExecuteIfTrue( parameter, true, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest6NullCheck()
        {
            Action<String> trueAction = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => trueAction.ExecuteIfTrue( RandomValueEx.GetRandomString(), true, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String> trueAction = ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2;
            trueAction.ExecuteIfTrue( parameter1, parameter2, true, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest7NullCheck()
        {
            Action<String, String> trueAction = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => trueAction.ExecuteIfTrue( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), true, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String, String> trueAction = ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3;
            trueAction.ExecuteIfTrue( parameter1, parameter2, parameter3, true, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest8NullCheck()
        {
            Action<String, String, String> trueAction = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => trueAction.ExecuteIfTrue( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          true,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTest9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 2
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                true );

            Assert.True( trueActionExecuted );

            // Case 3
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 4
            trueActionExecuted = false;
            ActionEx.ExecuteIfTrue(
                ( p1, p2, p3, p4 ) =>
                    trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4,
                parameter1,
                parameter2,
                parameter3,
                parameter4,
                true,
                false );

            Assert.False( trueActionExecuted );

            // Case 5
            trueActionExecuted = false;
            Action<String, String, String, String> trueAction = ( p1, p2, p3, p4 ) =>
                trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3 && p4 == parameter4;
            trueAction.ExecuteIfTrue( parameter1, parameter2, parameter3, parameter4, true, false );

            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfTrueTest9NullCheck()
        {
            Action<String, String, String, String> trueAction = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => trueAction.ExecuteIfTrue( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          true,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfTrueTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfTrue( null, null, true, true );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}