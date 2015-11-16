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
        public void SaveToInt64TestCase()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase1()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase2()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase3()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase4()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( RandomValueEx.GetRandomInt64() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase5()
        {
            var actual = "InvalidValue".SaveToInt64();

            Assert.AreEqual( default(Int64), actual );
        }

        [Test]
        public void SaveToInt64TestCase6()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt64() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64TestCase7()
        {
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Int64), actual );
        }

        [Test]
        public void SaveToInt64TestCaseNullCheck()
        {
            Action test = () => StringEx.SaveToInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToInt64TestCaseNullCheck1()
        {
            Action test = () => "".SaveToInt64( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}