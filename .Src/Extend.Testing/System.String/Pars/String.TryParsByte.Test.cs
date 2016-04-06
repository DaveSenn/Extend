#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void TryParsByteTest()
        {
            var expected = (Byte) 1;
            var result = (Byte) 3;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .TryParsByte( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsByteTest1()
        {
            var culture = new CultureInfo( "en-US" );
            var expected = (Byte) 1;
            var result = (Byte) 3;
            var actual = expected.ToString( culture )
                                 .TryParsByte( NumberStyles.Any, culture, out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsByteTest1NullCheck()
        {
            var outValue = (Byte) 1;
            Action test = () => StringEx.TryParsByte( null, NumberStyles.Any, CultureInfo.InvariantCulture, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsByteTest1NullCheck1()
        {
            var outValue = (Byte) 1;
            Action test = () => "".TryParsByte( NumberStyles.Any, null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryParsByteTestNullCheck()
        {
            var outValue = (Byte) 1;
            Action test = () => StringEx.TryParsByte( null, out outValue );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}