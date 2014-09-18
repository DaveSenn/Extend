#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void ToSecondsTestCase()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = ( (Int16) value ).ToSeconds();
            Assert.AreEqual( expected, actual );
        }
    }
}