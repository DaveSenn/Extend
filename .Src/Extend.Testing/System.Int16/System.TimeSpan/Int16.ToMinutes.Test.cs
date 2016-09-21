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
        public void ToMinutesTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMinutes( value );
            var actual = ( (Int16) value ).ToMinutes();
            Assert.AreEqual( expected, actual );
        }
    }
}