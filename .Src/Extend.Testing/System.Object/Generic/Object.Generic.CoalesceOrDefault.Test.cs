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
        public void CoalesceOrDefault1Test()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = expected.CoalesceOrDefault( s, null, null, "expected", "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceOrDefaultTest()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceOrDefaultTest2()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, () => s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, () => expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceOrDefaultTest2NullCheck()
        {
            String s = null;
            Func<String> func = null;
            Action test = () => s.CoalesceOrDefault( func, null, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CoalesceOrDefaultTest3()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = expected.CoalesceOrDefault( () => s, null, null, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceOrDefaultTestNullCheck()
        {
            String s = null;
            String s1 = null;
            Action test = () => s.CoalesceOrDefault( s1, null, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}