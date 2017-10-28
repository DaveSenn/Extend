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
        public void SafeExecuteExceptTest()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => { } );
            Assert.True( actual );

            actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => throw new InvalidCastException() );
            Assert.False( actual );
        }

        [Fact]
        public void SafeExecuteExceptTest_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException>( () => throw new ArgumentException() );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeExecuteExceptTest1()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>( () => { } );
            Assert.True( actual );

            actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                    () => throw new InvalidCastException() );
            Assert.False( actual );
        }

        [Fact]
        public void SafeExecuteExceptTest1_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => throw new ArgumentException() );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeExecuteExceptTest1_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => throw new NullReferenceException() );

            test.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeExecuteExceptTest1NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException, NullReferenceException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeExecuteExceptTest2()
        {
            var actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                    () => { } );
            Assert.True( actual );

            actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                    () => throw new InvalidCastException() );
            Assert.False( actual );
        }

        [Fact]
        public void SafeExecuteExceptTest2_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => throw new ArgumentException() );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeExecuteExceptTest2_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => throw new NullReferenceException() );

            test.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeExecuteExceptTest2_3()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => throw new InvalidOperationException() );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SafeExecuteExceptTest2NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeExecuteExceptTest3()
        {
            var actual =
                ActionEx
                    .SafeExecuteExcept
                    <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                        () => { } );
            Assert.True( actual );

            actual =
                ActionEx
                    .SafeExecuteExcept
                    <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                        () => throw new InvalidCastException() );
            Assert.False( actual );
        }

        [Fact]
        public void SafeExecuteExceptTest3_1()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                    () => throw new ArgumentException() );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeExecuteExceptTest3_2()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                    () => throw new NullReferenceException() );

            test.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeExecuteExceptTest3_3()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                    () => throw new InvalidOperationException() );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SafeExecuteExceptTest3_4()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>(
                    () => throw new ArithmeticException() );

            test.ShouldThrow<ArithmeticException>();
        }

        [Fact]
        public void SafeExecuteExceptTest3NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, ArithmeticException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeExecuteExceptTest4()
        {
            var actual = ActionEx.SafeExecuteExcept( () => { },
                                                     typeof(ArgumentException),
                                                     typeof(NullReferenceException),
                                                     typeof(InvalidOperationException),
                                                     typeof(ArithmeticException) );
            Assert.True( actual );

            actual = ActionEx.SafeExecuteExcept( () => throw new InvalidCastException(),
                                                 typeof(ArgumentException),
                                                 typeof(NullReferenceException),
                                                 typeof(InvalidOperationException),
                                                 typeof(ArithmeticException) );
            Assert.False( actual );
        }

        [Fact]
        public void SafeExecuteExceptTest4_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => throw new ArgumentException(),
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(ArithmeticException) );

            test.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SafeExecuteExceptTest4_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => throw new NullReferenceException(),
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(ArithmeticException) );

            test.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void SafeExecuteExceptTest4_3()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => throw new InvalidOperationException(),
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(ArithmeticException) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SafeExecuteExceptTest4_4()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => throw new ArithmeticException(),
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(ArithmeticException) );

            test.ShouldThrow<ArithmeticException>();
        }

        [Fact]
        public void SafeExecuteExceptTest4NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept( typeof(ArgumentException),
                                                          typeof(NullReferenceException),
                                                          typeof(InvalidOperationException),
                                                          typeof(ArithmeticException) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SafeExecuteExceptTestNullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException>();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}