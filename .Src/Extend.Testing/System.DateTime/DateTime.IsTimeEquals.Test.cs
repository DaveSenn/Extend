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
        public void IsTimeEqualTest()
        {
            var dateTime = DateTime.Now;
            var dateTime1 = dateTime.AddDays( -2 );

            var actual = dateTime.IsTimeEquals( dateTime1 );
            Assert.IsTrue( actual );

            dateTime1 = dateTime.AddDays( -2 )
                                .AddHours( 1 );

            actual = dateTime.IsTimeEquals( dateTime1 );
            Assert.IsFalse( actual );
        }
    }
}