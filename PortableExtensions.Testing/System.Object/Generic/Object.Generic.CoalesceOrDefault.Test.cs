#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void CoalesceOrDefaultTestCase()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoalesceOrDefaultTestCaseNullCheck()
        {
            String s = null;
            String s1 = null;
            s.CoalesceOrDefault( s1, null, null );
        }

        [TestCase]
        public void CoalesceOrDefaultTestCase1()
        {
            var expected = RandomValueEx.GetRandomString();
            String s = null;
            var actual = ObjectEx.CoalesceOrDefault( null, () => s, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );

            actual = ObjectEx.CoalesceOrDefault( null, () => expected, null, null );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoalesceOrDefaultTestCase1NullCheck()
        {
            String s = null;
            Func<String> func = null;
            s.CoalesceOrDefault( func, null, null );
        }
    }
}