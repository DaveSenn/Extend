#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ActionExTest
    {
        [Test]
        public void SafeExecuteExceptTestCase()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecuteExcept<ArgumentException>( () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SafeExecuteExceptTestCase1()
        {
            var actual = ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>( () => { } );
            Assert.IsTrue( actual );

            actual =
                ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                    () => { throw new InvalidCastException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SafeExecuteExceptTestCase1NullCheck()
        {
            Action action = null;
            action.SafeExecuteExcept<ArgumentException, NullReferenceException>();
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void SafeExecuteExceptTestCase1_1()
        {
            ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => { throw new ArgumentException(); } );
        }

        [Test]
        [ExpectedException( typeof (NullReferenceException) )]
        public void SafeExecuteExceptTestCase1_2()
        {
            ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException>(
                () => { throw new NullReferenceException(); } );
        }

        [Test]
        public void SafeExecuteExceptTestCase2()
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SafeExecuteExceptTestCase2NullCheck()
        {
            Action action = null;
            action.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>();
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void SafeExecuteExceptTestCase2_1()
        {
            ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new ArgumentException(); } );
        }

        [Test]
        [ExpectedException( typeof (NullReferenceException) )]
        public void SafeExecuteExceptTestCase2_2()
        {
            ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new NullReferenceException(); } );
        }

        [Test]
        [ExpectedException( typeof (InvalidOperationException) )]
        public void SafeExecuteExceptTestCase2_3()
        {
            ActionEx.SafeExecuteExcept<ArgumentException, NullReferenceException, InvalidOperationException>(
                () => { throw new InvalidOperationException(); } );
        }

        [Test]
        public void SafeExecuteExceptTestCase3()
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SafeExecuteExceptTestCase3NullCheck()
        {
            Action action = null;
            action
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>();
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void SafeExecuteExceptTestCase3_1()
        {
            ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new ArgumentException(); } );
        }

        [Test]
        [ExpectedException( typeof (NullReferenceException) )]
        public void SafeExecuteExceptTestCase3_2()
        {
            ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new NullReferenceException(); } );
        }

        [Test]
        [ExpectedException( typeof (InvalidOperationException) )]
        public void SafeExecuteExceptTestCase3_3()
        {
            ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new InvalidOperationException(); } );
        }

        [Test]
        [ExpectedException( typeof (AccessViolationException) )]
        public void SafeExecuteExceptTestCase3_4()
        {
            ActionEx
                .SafeExecuteExcept
                <ArgumentException, NullReferenceException, InvalidOperationException, AccessViolationException>(
                    () => { throw new AccessViolationException(); } );
        }

        [Test]
        public void SafeExecuteExceptTestCase4()
        {
            var actual = ActionEx.SafeExecuteExcept( () => { },
                                                     typeof (ArgumentException),
                                                     typeof (NullReferenceException),
                                                     typeof (InvalidOperationException),
                                                     typeof (AccessViolationException) );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecuteExcept( () => { throw new InvalidCastException(); },
                                                 typeof (ArgumentException),
                                                 typeof (NullReferenceException),
                                                 typeof (InvalidOperationException),
                                                 typeof (AccessViolationException) );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SafeExecuteExceptTestCase4NullCheck()
        {
            Action action = null;
            action.SafeExecuteExcept( typeof (ArgumentException),
                                      typeof (NullReferenceException),
                                      typeof (InvalidOperationException),
                                      typeof (AccessViolationException) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void SafeExecuteExceptTestCase4_1()
        {
            ActionEx.SafeExecuteExcept( () => { throw new ArgumentException(); },
                                        typeof (ArgumentException),
                                        typeof (NullReferenceException),
                                        typeof (InvalidOperationException),
                                        typeof (AccessViolationException) );
        }

        [Test]
        [ExpectedException( typeof (NullReferenceException) )]
        public void SafeExecuteExceptTestCase4_2()
        {
            ActionEx.SafeExecuteExcept( () => { throw new NullReferenceException(); },
                                        typeof (ArgumentException),
                                        typeof (NullReferenceException),
                                        typeof (InvalidOperationException),
                                        typeof (AccessViolationException) );
        }

        [Test]
        [ExpectedException( typeof (InvalidOperationException) )]
        public void SafeExecuteExceptTestCase4_3()
        {
            ActionEx.SafeExecuteExcept( () => { throw new InvalidOperationException(); },
                                        typeof (ArgumentException),
                                        typeof (NullReferenceException),
                                        typeof (InvalidOperationException),
                                        typeof (AccessViolationException) );
        }

        [Test]
        [ExpectedException( typeof (AccessViolationException) )]
        public void SafeExecuteExceptTestCase4_4()
        {
            ActionEx.SafeExecuteExcept( () => { throw new AccessViolationException(); },
                                        typeof (ArgumentException),
                                        typeof (NullReferenceException),
                                        typeof (InvalidOperationException),
                                        typeof (AccessViolationException) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SafeExecuteExceptTestCaseNullCheck()
        {
            Action action = null;
            action.SafeExecuteExcept<ArgumentException>();
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void SafeExecuteExceptTestCase_1()
        {
            ActionEx.SafeExecuteExcept<ArgumentException>( () => { throw new ArgumentException(); } );
        }
    }
}