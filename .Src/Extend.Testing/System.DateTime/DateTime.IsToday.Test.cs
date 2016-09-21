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
        public void IsTodayTest()
        {
            var dateTime = DateTime.Now;
            var actual = dateTime.IsToday();
            Assert.IsTrue( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsToday();
            Assert.IsFalse( actual );
        }
    }
}