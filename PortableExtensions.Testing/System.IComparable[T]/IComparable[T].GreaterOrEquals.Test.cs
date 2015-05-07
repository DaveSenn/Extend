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

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GreaterOrEqualsTestCaseNullCheck()
        {
            IComparableTEx.GreaterOrEquals( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GreaterOrEqualsTestCaseNullCheck1()
        {
            "".GreaterOrEquals( null );
        }
    }
}