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
        public void ToByteTestCase()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToByteTestCase1()
        {
            Byte expected = 1;
            var value = expected.ToString();
            var actual = ObjectEx.ToByte( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToByteTestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToByte( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTestCase1NullCheck1()
        {
            Action test = () => ObjectEx.ToByte( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByteTestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToByte( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}