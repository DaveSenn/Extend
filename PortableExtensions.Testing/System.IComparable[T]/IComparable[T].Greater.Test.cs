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
        public void GreaterTestCase()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Greater( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 900;

            actual = value.Greater( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 10;

            actual = value.Greater( value1 );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GreaterTestCaseNullCheck()
        {
            IComparableTEx.Greater( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GreaterTestCaseNullCheck1()
        {
            "".Greater( null );
        }
    }
}