#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void CoalesceTest()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTest1()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTest2()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTest3()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTest4()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            var actual = expected.Coalesce( value );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTest5()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            var actual = value.Coalesce( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestInvalidOperationCheck()
        {
            Object[] array = null;
            Action test = () => ObjectEx.Coalesce( null, array, null );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void CoalesceTestNullCheck()
        {
            String s = null;
            String[] array = null;
            Action test = () => s.Coalesce( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}