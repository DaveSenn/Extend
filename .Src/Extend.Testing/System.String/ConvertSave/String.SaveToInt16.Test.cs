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
        public void SaveToInt16Test()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test1()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test2()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test3()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = "InvalidValue".SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test4()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( RandomValueEx.GetRandomInt16() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test5()
        {
            var actual = "InvalidValue".SaveToInt16();

            Assert.AreEqual( default(Int16), actual );
        }

        [Test]
        public void SaveToInt16Test6()
        {
            var expected = RandomValueEx.GetRandomInt16();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt16() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt16Test7()
        {
            var actual = "InvalidValue".SaveToInt16( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Int16), actual );
        }

        [Test]
        public void SaveToInt16TestNullCheck1()
        {
            Action test = () => "".SaveToInt16( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}