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
        public void ToDaysTest()
        {
            var value = RandomValueEx.GetRandomInt32( 1, 100 );

            var expected = TimeSpan.FromDays( value );
            var actual = ( (Int64) value ).ToDays();
            Assert.AreEqual( expected, actual );
        }
    }
}