#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [Test]
        public void SmallerOrEqualsTestCase()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.SmallerOrEquals( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 900;

            actual = value.SmallerOrEquals( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 10;

            actual = value.SmallerOrEquals( value1 );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SmallerOrEqualsTestCaseNullCheck()
        {
            IComparableTEx.SmallerOrEquals( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SmallerOrEqualsTestCaseNullCheck1()
        {
            "".SmallerOrEquals( null );
        }
    }
}