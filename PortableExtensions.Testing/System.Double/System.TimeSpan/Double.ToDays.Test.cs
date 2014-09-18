#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void ToDaysTestCase()
        {
            var number = 10.5;
            var expected = TimeSpan.FromDays( number );
            var actual = number.ToDays();

            Assert.AreEqual( expected, actual );
        }
    }
}