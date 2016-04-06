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
        public void ConcatAllTest()
        {
            var actual = "test".ConcatAll( "0", "1", "2" );
            Assert.AreEqual( "test012", actual );
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
            Action test = () => values.ConcatAll();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllTestNullCheck()
        {
            String[] values = null;
            Action test = () => "test".ConcatAll( values );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}