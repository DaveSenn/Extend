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
        public void SmallerTestCase ()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Smaller( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 900;

            actual = value.Smaller( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 10;

            actual = value.Smaller( value1 );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SmallerTestCaseNullCheck ()
        {
            IComparableTEx.Smaller( null, "" );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void SmallerTestCaseNullCheck1 ()
        {
            "".Smaller( null );
        }
    }
}