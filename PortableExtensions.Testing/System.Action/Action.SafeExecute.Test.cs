#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ActionExTest
    {
        [Test]
        public void SafeExecuteTestCase ()
        {
            var actual = ActionEx.SafeExecute( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecute( () => { throw new Exception(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase1NullCheck ()
        {
            Action action = null;
            action.SafeExecute<Exception>();
        }

        [Test]
        public void SafeExecuteTestCase1_1 ()
        {
            var actual = ActionEx.SafeExecute<ArgumentNullException>( () => { } );
            Assert.IsTrue( actual );

            actual = ActionEx.SafeExecute<ArgumentNullException>( () => { throw new ArgumentNullException(); } );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException ( typeof (OutOfMemoryException) )]
        public void SafeExecuteTestCase1_2 ()
        {
            ActionEx.SafeExecute<ArgumentNullException>( () => { throw new OutOfMemoryException(); } );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase2NullCheck ()
        {
            Action action = null;
            action.SafeExecute<Exception, ArgumentOutOfRangeException>();
        }

        [Test]
        public void SafeExecuteTestCase2_1 ()
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
        [ExpectedException ( typeof (OutOfMemoryException) )]
        public void SafeExecuteTestCase2_2 ()
        {
            ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException>(
                () => { throw new OutOfMemoryException(); } );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase3NullCheck ()
        {
            Action action = null;
            action.SafeExecute<Exception, ArgumentOutOfRangeException, InvalidCastException>();
        }

        [Test]
        public void SafeExecuteTestCase3_1 ()
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
        [ExpectedException ( typeof (OutOfMemoryException) )]
        public void SafeExecuteTestCase3_2 ()
        {
            ActionEx.SafeExecute<ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException>(
                () => { throw new OutOfMemoryException(); } );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase4NullCheck ()
        {
            Action action = null;
            action.SafeExecute<Exception, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException>();
        }

        [Test]
        public void SafeExecuteTestCase4_1 ()
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
        [ExpectedException ( typeof (OutOfMemoryException) )]
        public void SafeExecuteTestCase4_2 ()
        {
            ActionEx
                .SafeExecute
                <ArgumentNullException, ArgumentOutOfRangeException, InvalidCastException, InvalidOperationException>(
                    () => { throw new OutOfMemoryException(); } );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase5NullCheck ()
        {
            Action action = null;
            action.SafeExecute( typeof (Exception), typeof (ArgumentException) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCase5NullCheck1 ()
        {
            Action action = () => { };
            Type[] types = null;
            action.SafeExecute( types );
        }

        [Test]
        public void SafeExecuteTestCase5_1 ()
        {
            var actual =
                ActionEx
                    .SafeExecute( () => { },
                                  typeof (ArgumentNullException),
                                  typeof (ArgumentOutOfRangeException),
                                  typeof (InvalidCastException),
                                  typeof (InvalidOperationException),
                                  typeof (ApplicationException) );
            Assert.IsTrue( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new ArgumentNullException(); },
                                  typeof (ArgumentNullException),
                                  typeof (ArgumentOutOfRangeException),
                                  typeof (InvalidCastException),
                                  typeof (InvalidOperationException),
                                  typeof (ApplicationException) );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new ArgumentOutOfRangeException(); },
                                  typeof (ArgumentNullException),
                                  typeof (ArgumentOutOfRangeException),
                                  typeof (InvalidCastException),
                                  typeof (InvalidOperationException),
                                  typeof (ApplicationException) );
            Assert.IsFalse( actual );

            actual =
                ActionEx
                    .SafeExecute( () => { throw new InvalidCastException(); },
                                  typeof (ArgumentNullException),
                                  typeof (ArgumentOutOfRangeException),
                                  typeof (InvalidCastException),
                                  typeof (InvalidOperationException),
                                  typeof (ApplicationException) );
            Assert.IsFalse( actual );

            actual = ActionEx.SafeExecute( () => { throw new InvalidOperationException(); },
                                           typeof (ArgumentNullException),
                                           typeof (ArgumentOutOfRangeException),
                                           typeof (InvalidCastException),
                                           typeof (InvalidOperationException),
                                           typeof (ApplicationException) );
            Assert.IsFalse( actual );

            actual = ActionEx.SafeExecute( () => { throw new ApplicationException(); },
                                           typeof (ArgumentNullException),
                                           typeof (ArgumentOutOfRangeException),
                                           typeof (InvalidCastException),
                                           typeof (InvalidOperationException),
                                           typeof (ApplicationException) );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException ( typeof (OutOfMemoryException) )]
        public void SafeExecuteTestCase5_2 ()
        {
            ActionEx.SafeExecute( () => { throw new OutOfMemoryException(); },
                                  typeof (ArgumentNullException),
                                  typeof (ArgumentOutOfRangeException),
                                  typeof (InvalidCastException),
                                  typeof (InvalidOperationException),
                                  typeof (ApplicationException) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SafeExecuteTestCaseNullCheck ()
        {
            Action action = null;
            action.SafeExecute();
        }
    }
}