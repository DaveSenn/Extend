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
        public void MaximumTest()
        {
            var actual = 1.Maximum( 2, 3, 4, 5, 6 );
            Assert.Equal( 6, actual );

            actual = 100.Maximum( 2, 3, 4, 5, 6 );
            Assert.Equal( 100, actual );
        }

        [Fact]
        public void MaximumTest1()
        {
            var actual = 1.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.Equal( "6", actual );

            actual = 100.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.Equal( "6", actual );
        }

        [Fact]
        public void MaximumTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MaximumTest1NullCheck1()
        {
            Func<Int32, Object> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Maximum( func, 1, 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MaximumTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 10.Maximum( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}