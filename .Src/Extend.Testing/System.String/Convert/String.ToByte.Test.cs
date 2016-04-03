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
        public void ToByteTestCase()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString()
                              .ToByte();

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToByteTestCase1()
        {
            const Byte value = (Byte) 1;
            var actual = value.ToString( CultureInfo.InvariantCulture )
                              .ToByte( CultureInfo.InvariantCulture );

            Assert.AreEqual( value, actual );
        }

        [Test]
        public void ToByteTestCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToByte( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTestCase1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".ToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTestCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => StringEx.ToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}