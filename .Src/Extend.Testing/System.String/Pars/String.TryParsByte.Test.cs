#region Usings

using System;
using System.Globalization;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsByteTestCase()
        {
            var expected = (byte) 1;
            var result = (byte) 3;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsByte( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsByteTestCase1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = (byte) 1;
            var result = (byte) 3;
            var actual = expected.ToString( culture )
                                 .TryParsByte( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsByteTestCase1NullCheck()
        {
            var outValue = (byte) 1;
            StringEx.TryParsByte( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsByteTestCase1NullCheck1()
        {
            var outValue = (byte) 1;
            "".TryParsByte( NumberStyles.Any, null, out outValue );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryParsByteTestCaseNullCheck()
        {
            var outValue = (byte) 1;
            StringEx.TryParsByte( null, out outValue );
        }
    }
}