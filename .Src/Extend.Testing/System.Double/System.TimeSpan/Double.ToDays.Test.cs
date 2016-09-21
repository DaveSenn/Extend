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
        public void ToDaysTest()
        {
            var number = 10.5;
            var expected = TimeSpan.FromDays( number );
            var actual = number.ToDays();

            Assert.AreEqual( expected, actual );
        }
    }
}