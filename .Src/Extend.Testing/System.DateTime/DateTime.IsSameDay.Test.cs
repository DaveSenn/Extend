#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class DateTimeExTest
    {
        [Fact]
        public void IsSameDayTest()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now;

            Assert.True( dateTime.IsSameDay( otherDateTime ) );
        }

        [Fact]
        public void IsSameDayTest1()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Tomorrow();

            Assert.False( dateTime.IsSameDay( otherDateTime ) );
        }

        [Fact]
        public void IsSameDayTest2()
        {
            var dateTime = DateTime.Now;
            var otherDateTime = DateTime.Now.Yesterday();

            Assert.False( dateTime.IsSameDay( otherDateTime ) );
        }
    }
}