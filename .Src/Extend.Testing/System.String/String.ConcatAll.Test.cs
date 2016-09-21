#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ConcatAllNullTest()
        {
            String value = null;
            var actual = value.ConcatAll( "0", "1", "2" );

            actual
                .Should()
                .Be( "012" );
        }

        [Test]
        public void ConcatAllNullTest1()
        {
            String value = null;
            var actual = value.ConcatAll( null, "1", "2" );

            actual
                .Should()
                .Be( "12" );
        }

        [Test]
        public void ConcatAllNullTest2()
        {
            String value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => value.ConcatAll( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllNullTest3()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.ConcatAll( null, null, null );

            actual
                .Should()
                .Be( "" );
        }

        [Test]
        public void ConcatAllTest()
        {
            var actual = "test".ConcatAll( "0", "1", "2" );

            actual
                .Should()
                .Be( "test012" );
        }

        [Test]
        public void ConcatAllTest1()
        {
            var actual = new[]
            {
                "test",
                "0",
                "1",
                "2"
            }.ConcatAll();
            Assert.AreEqual( "test012", actual );
        }

        [Test]
        public void ConcatAllTest1NullCheck()
        {
            String[] values = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => values.ConcatAll();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllTest2()
        {
            var actual = "test".ConcatAll( new Object[]
                                           {
                                               "0",
                                               "1",
                                               "2"
                                           } );
            Assert.AreEqual( "test012", actual );
        }

        [Test]
        public void ConcatAllTest2NullCheck()
        {
            Object[] values = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ConcatAll( values );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllTest3()
        {
            var actual = new Object[]
            {
                "test",
                "0",
                "1",
                "2"
            }.ConcatAll();
            Assert.AreEqual( "test012", actual );
        }

        [Test]
        public void ConcatAllTest3NullCheck()
        {
            Object[] values = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => values.ConcatAll();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllTestNullCheck()
        {
            String[] values = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "test".ConcatAll( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}