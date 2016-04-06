#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void ToSecondsTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromSeconds( value );
            var actual = ( (Int64) value ).ToSeconds();
            Assert.AreEqual( expected, actual );
        }
    }
}