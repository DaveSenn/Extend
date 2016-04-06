#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToByteTest()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToByteTest1()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToByteTest1NullCheck()
        {
            Action test = () => ObjectEx.ToByte( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTest1NullCheck1()
        {
            Action test = () => ObjectEx.ToByte( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTestNullCheck()
        {
            Action test = () => ObjectEx.ToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}