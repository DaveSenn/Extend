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
        public void ExecuteIfAnyFalseTest()
        {
            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => { },
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => trueActionExecuted = true,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => trueActionExecuted = true,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.True( trueActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                () => { },
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => { },
                () => { },
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest1()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                p1 => trueActionExecuted = p1 == parameter,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                p1 => trueActionExecuted = p1 == parameter,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.True( trueActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                null,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyFalse( null, RandomValueEx.GetRandomString(), null, false, true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest2()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var trueActionExecuted = false;
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 3
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                ( p1, p2 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.True( trueActionExecuted );

            // Case 4
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 5
            falseActionExecuted = false;
            trueActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                null,
                true,
                true );

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyFalse( null,
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            null,
                                                            false,
                                                            true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest3()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
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

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                ( p1, p2, p3 ) => trueActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                false,
                true );

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 3
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

            Assert.False( falseActionExecuted );
            Assert.True( trueActionExecuted );

            // Case 4
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

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 5
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

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyFalse( null,
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            RandomValueEx.GetRandomString(),
                                                            null,
                                                            false,
                                                            true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest4()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1
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

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 2
            // ReSharper disable once HeuristicUnreachableCode
            falseActionExecuted = false;
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

            Assert.True( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 3
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

            Assert.False( falseActionExecuted );
            Assert.True( trueActionExecuted );

            // Case 4
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

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );

            // Case 5
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

            Assert.False( falseActionExecuted );
            Assert.False( trueActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest4NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
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

        [Fact]
        public void ExecuteIfAnyFalseTest5()
        {
            // Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                () => falseActionExecuted = true,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            Action action = () => { };
            falseActionExecuted = false;
            action.ExecuteIfAnyFalse( true, true );

            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest5NullCheck()
        {
            Action action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyFalse( false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest6()
        {
            var parameter = RandomValueEx.GetRandomString();

            // Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                p1 => falseActionExecuted = p1 == parameter,
                parameter,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            Action<String> action = x => { };
            action.ExecuteIfAnyFalse( parameter, true, true );

            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest6NullCheck()
        {
            Action<String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), false, true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest7()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();

            // Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2,
                parameter1,
                parameter2,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            Action<String, String> action = ( x, y ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, true, true );

            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest7NullCheck()
        {
            Action<String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString(), false, true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest8()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();

            // Case 1
            var falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 2
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                false,
                true );

            Assert.True( falseActionExecuted );

            // Case 3
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 4
            falseActionExecuted = false;
            ActionEx.ExecuteIfAnyFalse(
                ( p1, p2, p3 ) => falseActionExecuted = p1 == parameter1 && p2 == parameter2 && p3 == parameter3,
                parameter1,
                parameter2,
                parameter3,
                true,
                true );

            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            Action<String, String, String> action = ( x, y, z ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, true, true );

            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest8NullCheck()
        {
            Action<String, String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          false,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTest9()
        {
            var parameter1 = RandomValueEx.GetRandomString();
            var parameter2 = RandomValueEx.GetRandomString();
            var parameter3 = RandomValueEx.GetRandomString();
            var parameter4 = RandomValueEx.GetRandomString();

            // Case 1$
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

            Assert.True( falseActionExecuted );

            // Case 2
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

            Assert.True( falseActionExecuted );

            // Case 3
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

            Assert.False( falseActionExecuted );

            // Case 4
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

            Assert.False( falseActionExecuted );

            // Case 5
            falseActionExecuted = false;
            Action<String, String, String, String> action = ( x, y, z, a ) => { };
            action.ExecuteIfAnyFalse( parameter1, parameter2, parameter3, parameter4, true, true );

            Assert.False( falseActionExecuted );
        }

        [Fact]
        public void ExecuteIfAnyFalseTest9NullCheck()
        {
            Action<String, String, String, String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => action.ExecuteIfAnyFalse( RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          RandomValueEx.GetRandomString(),
                                                          false,
                                                          true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteIfAnyFalseTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => ActionEx.ExecuteIfAnyFalse( null, null, false, true );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}