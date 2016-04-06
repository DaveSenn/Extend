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
        public void MaximumTest()
        {
            var actual = 1.Maximum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 6, actual );

            actual = 100.Maximum( 2, 3, 4, 5, 6 );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void MaximumTest1()
        {
            var actual = 1.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "6", actual );

            actual = 100.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), 2, 3, 4, 5, 6 );
            Assert.AreEqual( "6", actual );
        }

        [Test]
        public void MaximumTest1NullCheck()
        {
            Action test = () => 10.Maximum( x => x.ToString( CultureInfo.InvariantCulture ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MaximumTest1NullCheck1()
        {
            Func<Int32, Object> func = null;
            Action test = () => 10.Maximum( func, 1, 2, 3, 4, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MaximumTestNullCheck()
        {
            Action test = () => 10.Maximum( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}