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
        public void SafeExecuteExceptTest()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTest_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException>( () => { throw new ArgumentException(); } );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SafeExecuteExceptTest1()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>( () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                    () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTest1_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => { throw new ArgumentException(); } );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SafeExecuteExceptTest1_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => { throw new NullReferenceException(); } );

            test.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void SafeExecuteExceptTest1NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException, NullReferenceException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteExceptTest2()
        {
            var actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                    () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                    () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTest2_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new ArgumentException(); } );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SafeExecuteExceptTest2_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new NullReferenceException(); } );

            test.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void SafeExecuteExceptTest2_3()
        {
            Action test = () => ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new InvalidOperationException(); } );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void SafeExecuteExceptTest2NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteExceptTest3()
        {
            var actual =
                ActionEx
                    .SafeExecuteExcept
                    <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                        () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx
                    .SafeExecuteExcept
                    <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                        () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTest3_1()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new ArgumentException(); } );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SafeExecuteExceptTest3_2()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new NullReferenceException(); } );

            test.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void SafeExecuteExceptTest3_3()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new InvalidOperationException(); } );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void SafeExecuteExceptTest3_4()
        {
            Action test = () => ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new AccessViolationException(); } );

            test.ShouldThrow<AccessViolationException>();
        }

        [Test]
        public void SafeExecuteExceptTest3NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteExceptTest4()
        {
            var actual = ActionEx.SafeExecuteExcept( () => { },
                                                     typeof(ArgumentException),
                                                     typeof(NullReferenceException),
                                                     typeof(InvalidOperationException),
                                                     typeof(AccessViolationException) );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecuteExcept( () => { throw new InvalidCastException(); },
                                                 typeof(ArgumentException),
                                                 typeof(NullReferenceException),
                                                 typeof(InvalidOperationException),
                                                 typeof(AccessViolationException) );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTest4_1()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => { throw new ArgumentException(); },
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(AccessViolationException) );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void SafeExecuteExceptTest4_2()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => { throw new NullReferenceException(); },
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(AccessViolationException) );

            test.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void SafeExecuteExceptTest4_3()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => { throw new InvalidOperationException(); },
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(AccessViolationException) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void SafeExecuteExceptTest4_4()
        {
            Action test = () => ActionEx.SafeExecuteExcept( () => { throw new AccessViolationException(); },
                                                            typeof(ArgumentException),
                                                            typeof(NullReferenceException),
                                                            typeof(InvalidOperationException),
                                                            typeof(AccessViolationException) );

            test.ShouldThrow<AccessViolationException>();
        }

        [Test]
        public void SafeExecuteExceptTest4NullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept( typeof(ArgumentException),
                                                          typeof(NullReferenceException),
                                                          typeof(InvalidOperationException),
                                                          typeof(AccessViolationException) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteExceptTestNullCheck()
        {
            Action action = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => action.SafeExecuteExcept<ArgumentException>();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}