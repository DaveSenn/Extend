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
        public void CoalesceTestCase()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoalesceTestCaseNullCheck()
        {
            String s = null;
            String[] array = null;
            s.Coalesce( array );
        }

        [TestCase]
        [ExpectedException( typeof ( InvalidOperationException ) )]
        public void CoalesceTestCaseInvalidOperationCheck()
        {
            Object[] array = null;
            ObjectEx.Coalesce( null, array, null );
        }

        [TestCase]
        public void CoalesceTestCase1()
        {
            var expected = RandomValueEx.GetRandomString();
            var actual = ObjectEx.Coalesce( null, null, null, null, expected, "Test2" );

            Assert.AreEqual( expected, actual );
        }
    }
}