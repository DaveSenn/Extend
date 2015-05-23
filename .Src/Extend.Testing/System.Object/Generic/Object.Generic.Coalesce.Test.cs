#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void CoalesceTestCase()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestCase1()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestCase2()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestCase3()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = expected.Coalesce( "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestCase4()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            var actual = expected.Coalesce( value );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceTestCase5()
        {
            var expected = RandomValueEx.GetRandomString();
            String value = null;
            var actual = value.Coalesce( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof (InvalidOperationException) )]
        public void CoalesceTestCaseInvalidOperationCheck()
        {
            Object[] array = null;
            ObjectEx.Coalesce( null, array, null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void CoalesceTestCaseNullCheck()
        {
            String s = null;
            String[] array = null;
            s.Coalesce( array );
        }
    }
}