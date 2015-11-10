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
        public void SaveToByteTestCase()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase1()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( default(Byte) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase2()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase3()
        {
            var actual = "InvalidValue".SaveToByte();

            Assert.AreEqual( default(Byte), actual );
        }

        [Test]
        public void SaveToByteTestCase4()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase5()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture, 11 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase6()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture,
                                                    expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTestCase7()
        {
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Byte), actual );
        }

        [Test]
        public void SaveToByteTestCaseNullCheck()
        {
            Action test = () => StringEx.SaveToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToByteTestCaseNullCheck1()
        {
            Action test = () => "".SaveToByte( NumberStyles.AllowDecimalPoint, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}