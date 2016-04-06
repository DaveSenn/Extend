#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void ToSecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = value.ToSeconds();
            Assert.AreEqual( expected, actual );
        }
    }
}