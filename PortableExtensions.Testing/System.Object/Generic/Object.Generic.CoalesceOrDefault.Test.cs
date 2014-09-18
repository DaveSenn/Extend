#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void CoalesceOrDefaultTestCase()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void CoalesceOrDefault1TestCase()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = expected.CoalesceOrDefault(s, null, null, "expected", "Test2");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoalesceOrDefaultTestCaseNullCheck()
        {
            String s = null;
            String s1 = null;
            s.CoalesceOrDefault( s1, null, null );
        }

        [Test]
        public void CoalesceOrDefaultTestCase2()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, () => s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, () => expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoalesceOrDefaultTestCase2NullCheck()
        {
            String s = null;
            Func<String> func = null;
            s.CoalesceOrDefault( func, null, null );
        }

        [Test]
        public void CoalesceOrDefaultTestCase3()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = expected.CoalesceOrDefault(() => s, null, null, "Test2");

            Assert.AreEqual(expected, actual);
        }
    }
}