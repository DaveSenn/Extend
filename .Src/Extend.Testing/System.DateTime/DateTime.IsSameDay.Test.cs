#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void IsSameDayTestCase()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now;

            Assert.IsTrue( dateTime.IsSameDay( otherDateTime ) );
        }

        [Test]
        public void IsSameDayTestCase1()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Tomorrow();

            Assert.IsFalse( dateTime.IsSameDay( otherDateTime ) );
        }

        [Test]
        public void IsSameDayTestCase2()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Yesterday();

            Assert.IsFalse( dateTime.IsSameDay( otherDateTime ) );
        }
    }
}