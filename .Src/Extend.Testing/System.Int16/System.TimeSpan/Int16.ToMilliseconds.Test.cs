#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void ToMillisecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMilliseconds( value );
            var actual = ( (Int16) value ).ToMilliseconds();
            Assert.AreEqual( expected, actual );
        }
    }
}