#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void ToHoursTest()
        {
            const Double number = 10.5;
            var expected = TimeSpan.FromHours( number );
            var actual = number.ToHours();

            Assert.AreEqual( expected, actual );
        }
    }
}