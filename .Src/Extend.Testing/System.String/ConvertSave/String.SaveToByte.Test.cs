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
        public void SaveToByteTest()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest1()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( default(Byte) );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest2()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest3()
        {
            var actual = "InvalidValue".SaveToByte();

            Assert.AreEqual( default(Byte), actual );
        }

        [Test]
        public void SaveToByteTest4()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest5()
        {
            const Byte expected = (Byte) 10;
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToByte( NumberStyles.Any, CultureInfo.InvariantCulture, 11 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest6()
        {
            const Byte expected = (Byte) 10;
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture,
                                                    expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToByteTest7()
        {
            var actual = "InvalidValue".SaveToByte( NumberStyles.AllowDecimalPoint,
                                                    CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Byte), actual );
        }

        [Test]
        public void SaveToByteTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.SaveToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToByteTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".SaveToByte( NumberStyles.AllowDecimalPoint, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}