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
        public void ToMinutesTestCase()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromMinutes( value );
            var actual = value.ToMinutes();
            Assert.AreEqual( expected, actual );
        }
    }
}