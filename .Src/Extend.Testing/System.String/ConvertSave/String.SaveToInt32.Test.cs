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
        public void SaveToInt32Test()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test1()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test2()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test3()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test4()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( RandomValueEx.GetRandomInt32() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test5()
        {
            var actual = "InvalidValue".SaveToInt32();

            Assert.AreEqual( default(Int32), actual );
        }

        [Test]
        public void SaveToInt32Test6()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var actual = expected.ToString( CultureInfo.InvariantCulture )
                                 .SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture, RandomValueEx.GetRandomInt32() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToInt32Test7()
        {
            var actual = "InvalidValue".SaveToInt32( NumberStyles.Any, CultureInfo.InvariantCulture );

            Assert.AreEqual( default(Int32), actual );
        }
        
        [Test]
        public void SaveToInt32TestNullCheck1()
        {
            Action test = () => "".SaveToInt32( NumberStyles.AllowExponent, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}