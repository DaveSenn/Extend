#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void ToHoursTestCase ()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromHours( value );
            var actual = ( (Int64) value ).ToHours();
            Assert.AreEqual( expected, actual );
        }
    }
}