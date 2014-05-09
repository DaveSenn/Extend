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
        public void GreaterOrEqualsTestCase()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.GreaterOrEquals( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 900;

            actual = value.GreaterOrEquals( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 10;

            actual = value.GreaterOrEquals( value1 );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GreaterOrEqualsTestCaseNullCheck()
        {
            IComparableTEx.GreaterOrEquals( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GreaterOrEqualsTestCaseNullCheck1()
        {
            "".GreaterOrEquals( null );
        }
    }
}