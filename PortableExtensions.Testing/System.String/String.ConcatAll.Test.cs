#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ConcatAllTestCase ()
        {
            var actual = "test".ConcatAll( "0", "1", "2" );
            Assert.AreEqual( "test012", actual );
        }

        [Test]
        public void ConcatAllTestCase1 ()
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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ConcatAllTestCase1NullCheck ()
        {
            String[] values = null;
            var actual = values.ConcatAll();
        }

        [Test]
        public void ConcatAllTestCase2 ()
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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ConcatAllTestCase2NullCheck ()
        {
            Object[] values = null;
            var actual = "test".ConcatAll( values );
        }

        [Test]
        public void ConcatAllTestCase3 ()
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
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ConcatAllTestCase3NullCheck ()
        {
            Object[] values = null;
            var actual = values.ConcatAll();
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ConcatAllTestCaseNullCheck ()
        {
            String[] values = null;
            var actual = "test".ConcatAll( values );
        }
    }
}