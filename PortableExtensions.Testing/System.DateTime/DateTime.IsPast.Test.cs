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