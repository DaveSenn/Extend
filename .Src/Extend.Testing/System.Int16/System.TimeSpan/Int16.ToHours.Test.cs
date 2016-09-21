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
        public void ToHoursTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = ( (Int16) value ).ToHours();
            Assert.AreEqual( expected, actual );
        }
    }
}