#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void ToMillisecondsTestCase()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMilliseconds( value );
            var actual = value.ToMilliseconds();
            Assert.AreEqual( expected, actual );
        }
    }
}