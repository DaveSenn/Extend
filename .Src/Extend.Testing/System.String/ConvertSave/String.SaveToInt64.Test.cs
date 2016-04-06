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
        public void SaveToInt64Test()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test1()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test2()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test3()
        {
            var expected = (Int64) RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test4()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( RandomValueEx.GetRandomInt64() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test5()
        {
            var actual = "InvalidValue".SaveToInt64();

            Assert.AreEqual( default(Int64), actual );
        }

        [Test]
        public void SaveToInt64Test6()
        {
            var expected = RandomValueEx.GetRandomInt64();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt64() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt64Test7()
        {
            var actual = "InvalidValue".SaveToInt64( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Int64), actual );
        }

        [Test]
        public void SaveToInt64TestNullCheck()
        {
            Action test = () => StringEx.SaveToInt64( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SaveToInt64TestNullCheck1()
        {
            Action test = () => "".SaveToInt64( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}