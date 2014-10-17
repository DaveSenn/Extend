#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [Test]
        public void BetweenTestCase ()
        {
            var value = 100;
            var min = 50;
            var max = 300;

            var actual = value.Between( min, max );
            Assert.IsTrue( actual );

            value = 100;
            min = 50;
            max = 100;

            actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTestCase1 ()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTestCase3 ()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTestCase4 ()
        {
            const Int32 value = 4;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void BetweenTestCaseNullCheck ()
        {
            IComparableTEx.Between( null, "", "" );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void BetweenTestCaseNullCheck1 ()
        {
            "".Between( null, "" );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void BetweenTestCaseNullCheck2 ()
        {
            "".Between( "", null );
        }
    }
}