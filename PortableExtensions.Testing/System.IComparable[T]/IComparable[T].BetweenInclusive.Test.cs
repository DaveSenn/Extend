#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [TestCase]
        public void BetweenInclusiveTestCase()
        {
            var value = 100;
            var min = 50;
            var max = 300;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );

            value = 100;
            min = 50;
            max = 100;

            actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );

            value = 100;
            min = 50;
            max = 99;

            actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenInclusiveTestCaseNullCheck()
        {
            IComparableTEx.BetweenInclusive( null, "", "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenInclusiveTestCaseNullCheck1()
        {
            "".BetweenInclusive( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void BetweenInclusiveTestCaseNullCheck2()
        {
            "".BetweenInclusive( "", null );
        }
    }
}