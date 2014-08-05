#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [TestCase]
        public void IsSameDayTestCase()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now;

            Assert.IsTrue( dateTime.IsSameDay( otherDateTime ) );
        }

        [TestCase]
        public void IsSameDayTestCase1()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Tomorrow();

            Assert.IsFalse( dateTime.IsSameDay( otherDateTime ) );
        }

        [TestCase]
        public void IsSameDayTestCase2()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Yesterday();

            Assert.IsFalse( dateTime.IsSameDay( otherDateTime ) );
        }
    }
}