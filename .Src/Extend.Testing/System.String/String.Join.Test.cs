#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void JoinTest()
        {
            var actual = ",".Join( new[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        public void JoinTest1()
        {
            var actual = ",".Join( new Object[]
            {
                "1",
                "2"
            } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        public void JoinTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Join( null,
                                               new Object[]
                                               {
                                               } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest1NullCheck1()
        {
            Object[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Join( array );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest2()
        {
            var actual = ",".Join( new List<String> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        public void JoinTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Join( null,
                                               new Object[]
                                               {
                                               } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest2NullCheck1()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Join( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest3()
        {
            var actual = ",".Join( new List<Object> { "1", "2" } );
            Assert.AreEqual( "1,2", actual );
        }

        [Test]
        public void JoinTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Join( null,
                                               new Object[]
                                               {
                                               } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest3NullCheck1()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Join( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest4()
        {
            var array = new[]
            {
                "1",
                "2",
                "3"
            };

            var actual = ",".Join( array, 1, 2 );
            Assert.AreEqual( "2,3", actual );
        }

        [Test]
        public void JoinTest4NullCheck()
        {
            String seperator = null;
            var array = new[]
            {
                "1",
                "2",
                "3"
            };

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => seperator.Join( array, 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTest4NullCheck1()
        {
            String[] array = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => ",".Join( array, 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Join( null,
                                               new String[]
                                               {
                                               } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void JoinTestNullCheck1()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Join( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}