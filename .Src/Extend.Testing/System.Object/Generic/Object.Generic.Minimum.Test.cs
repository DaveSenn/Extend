#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void MinimumTest()
        {
            var actual = 1.Minimum( 2, 3, 4, 5, 6 );
            Assert.Equal( 1, actual );

            actual = 100.Minimum( 2, 3, 4, 5, 6 );
            Assert.Equal( 2, actual );
        }

        [Fact]
        public void MinimumTest1()
        {
            var actual = 1.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.Equal( "1", actual );

            actual = 100.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.Equal( "100", actual );
        }

        [Fact]
        public void MinimumTest1NullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => 10.Minimum( x => x.ToString( CultureInfo.InvariantCulture ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MinimumTest1NullCheck1()
        {
            Func<Int32, Object> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Minimum( func, 1, 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MinimumTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Minimum( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}