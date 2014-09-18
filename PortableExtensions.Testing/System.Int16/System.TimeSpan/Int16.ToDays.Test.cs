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
        public void ToDaysTestCase()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromDays( value );
            var actual = ( (Int16) value ).ToDays();
            Assert.AreEqual( expected, actual );
        }
    }
}