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
        public void MinimumTestCase()
        {
            var actual = 1.Minimum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 1, actual );

            actual = 100.Minimum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void MinimumTestCase1()
        {
            var actual = 1.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "1", actual );

            actual = 100.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "100", actual );
        }

        [Test]
        public void MinimumTestCase1NullCheck()
        {
            Action test = () => 10.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumTestCase1NullCheck1()
        {
            Func<Int32, Object> func = null;
            Action test = () => 10.Minimum( func, 1, 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumTestCaseNullCheck()
        {
            Action test = () => 10.Minimum( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}