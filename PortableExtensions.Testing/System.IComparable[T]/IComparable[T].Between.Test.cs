#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [Test]
        public void BetweenTestCase()
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
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenTestCaseNullCheck()
        {
            IComparableTEx.Between( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenTestCaseNullCheck1()
        {
            "".Between( null, "" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenTestCaseNullCheck2()
        {
            "".Between( "", null );
        }
    }
}