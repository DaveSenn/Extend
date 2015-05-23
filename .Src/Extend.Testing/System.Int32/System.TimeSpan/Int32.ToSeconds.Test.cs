#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void ToSecondsTestCase()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = value.ToSeconds();
            Assert.AreEqual( expected, actual );
        }
    }
}