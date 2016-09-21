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
        public void SafeExecuteTest()
        {
            var actual = ActionEx.SafeExecute( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecute( () => { throw new Exception(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest1_1()
        {
            var actual = ActionEx.SafeExecute<ArgumentNullException>( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecute<ArgumentNullException>( () => { throw new ArgumentNullException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest1_2()
        {
            Action test = () => ActionEx.SafeExecute<ArgumentNullException>( () => { throw new OutOfMemoryException(); } );

            test.ShouldThrow<OutOfMemoryException>();
        }

        [Test]
        public void SafeExecuteTest1NullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTest2_1()
        {
            var actual = ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException>( () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException>(
                    () => { throw new ArgumentNullException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException>(
                    () => { throw new ArgumentOutOfRangeException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest2_2()
        {
            Action test = () => ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException>(
                () => { throw new OutOfMemoryException(); } );

            test.ShouldThrow<OutOfMemoryException>();
        }

        [Test]
        public void SafeExecuteTest2NullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTest3_1()
        {
            var actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                    () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                    () => { throw new ArgumentNullException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                    () => { throw new ArgumentOutOfRangeException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                    () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest3_2()
        {
            Action test = () => ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                () => { throw new OutOfMemoryException(); } );

            test.ShouldThrow<OutOfMemoryException>();
        }

        [Test]
        public void SafeExecuteTest3NullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTest4_1()
        {
            var actual =
                ActionEx
                    .SafeExecute
                    <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException
                    >( () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx
                    .SafeExecute
                    <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException
                    >( () => { throw new ArgumentNullException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute
                    <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException
                    >( () => { throw new ArgumentOutOfRangeException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute
                    <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException
                    >( () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute
                    <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException
                    >( () => { throw new InvalidOperationException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest4_2()
        {
            Action test = () => ActionEx
                .SafeExecute
                <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException>(
                    () => { throw new OutOfMemoryException(); } );

            test.ShouldThrow<OutOfMemoryException>();
        }

        [Test]
        public void SafeExecuteTest4NullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTest5_1()
        {
            var actual =
                ActionEx
                    .SafeExecute( () => { },
                                  typeof(ArgumentNullException),
                                  typeof(ArgumentOutOfRangeException),
                                  typeof(InvalidCastException),
                                  typeof(InvalidOperationException),
                                  typeof(ApplicationException) );
            Assert.IsTrue( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new ArgumentNullException(); },
                                  typeof(ArgumentNullException),
                                  typeof(ArgumentOutOfRangeException),
                                  typeof(InvalidCastException),
                                  typeof(InvalidOperationException),
                                  typeof(ApplicationException) );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new ArgumentOutOfRangeException(); },
                                  typeof(ArgumentNullException),
                                  typeof(ArgumentOutOfRangeException),
                                  typeof(InvalidCastException),
                                  typeof(InvalidOperationException),
                                  typeof(ApplicationException) );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new InvalidCastException(); },
                                  typeof(ArgumentNullException),
                                  typeof(ArgumentOutOfRangeException),
                                  typeof(InvalidCastException),
                                  typeof(InvalidOperationException),
                                  typeof(ApplicationException) );
            Assert.IsFalse( actual );

            actual = ActionEx.SafeExecute( () => { throw new InvalidOperationException(); },
                                           typeof(ArgumentNullException),
                                           typeof(ArgumentOutOfRangeException),
                                           typeof(InvalidCastException),
                                           typeof(InvalidOperationException),
                                           typeof(ApplicationException) );
            Assert.IsFalse( actual );

            actual = ActionEx.SafeExecute( () => { throw new ApplicationException(); },
                                           typeof(ArgumentNullException),
                                           typeof(ArgumentOutOfRangeException),
                                           typeof(InvalidCastException),
                                           typeof(InvalidOperationException),
                                           typeof(ApplicationException) );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteTest5_2()
        {
            Action test = () => ActionEx.SafeExecute( () => { throw new OutOfMemoryException(); },
                                                      typeof(ArgumentNullException),
                                                      typeof(ArgumentOutOfRangeException),
                                                      typeof(InvalidCastException),
                                                      typeof(InvalidOperationException),
                                                      typeof(ApplicationException) );

            test.ShouldThrow<OutOfMemoryException>();
        }

        [Test]
        public void SafeExecuteTest5NullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute( typeof(Exception), typeof(ArgumentException) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTest5NullCheck1()
        {
            Action action = () => { };
            Type[] types = null;
            Action test = () => action.SafeExecute( types );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SafeExecuteTestNullCheck()
        {
            Action action = null;
            Action test = () => action.SafeExecute();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}