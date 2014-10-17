#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsBooleanTestCase ()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var result = !expected;
            var actual = expected.ToString( CultureInfo.InvariantCulture ).TryParsBoolean( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void TryParsBooleanTestCaseNullCheck ()
        {
            var outValue = false;
            StringEx.TryParsBoolean( null, out outValue );
        }
    }
}