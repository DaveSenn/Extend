#region Using

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void TryParsCharTestCase()
        {
            var expected = 'b';
            var result = 'a';
            var actual = expected.ToString( CultureInfo.InvariantCulture ).TryParsChar( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryParsCharTestCaseNullCheck()
        {
            var outValue = 's';
            StringEx.TryParsChar( null, out outValue );
        }
    }
}