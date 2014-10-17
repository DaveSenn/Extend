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
        public void IsNumericTestCase ()
        {
            var actual = "test".IsNumeric();
            Assert.IsFalse( actual );

            actual = "1test".IsNumeric();
            Assert.IsFalse( actual );

            actual = "123".IsNumeric();
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void IsNumericTestCaseNullCheck ()
        {
            StringEx.IsNumeric( null );
        }
    }
}