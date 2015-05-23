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
        public void IsPastTestCase()
        {
            var dateTime = DateTime.Now.Subtract( 1.ToMilliseconds() );
            var actual = dateTime.IsPast();
            Assert.IsTrue( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsPast();
            Assert.IsFalse( actual );
        }
    }
}