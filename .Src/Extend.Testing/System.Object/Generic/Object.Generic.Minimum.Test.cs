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
        public void MinimumTest()
        {
            var actual = 1.Minimum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 1, actual );

            actual = 100.Minimum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 2, actual );
        }

        [Test]
        public void MinimumTest1()
        {
            var actual = 1.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "1", actual );

            actual = 100.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "100", actual );
        }

        [Test]
        public void MinimumTest1NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => 10.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumTest1NullCheck1()
        {
            Func<Int32, Object> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Minimum( func, 1, 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Minimum( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}