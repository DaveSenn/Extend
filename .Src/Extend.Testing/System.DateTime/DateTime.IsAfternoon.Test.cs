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
        public void IsAfternoonTest()
        {
            var dateTime = new DateTime( 2014, 10, 10, 13, 0, 0 );
            var actual = dateTime.IsAfternoon();
            Assert.IsTrue( actual );

            dateTime = new DateTime( 2014, 10, 10, 10, 0, 0 );
            actual = dateTime.IsAfternoon();
            Assert.IsFalse( actual );
        }
    }
}