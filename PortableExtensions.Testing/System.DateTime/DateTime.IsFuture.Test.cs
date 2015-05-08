#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class DateTimeExTest
    {
        [Test]
        public void IsFutureTestCase()
        {
            var dateTime = DateTime.Now.Subtract( 1.ToMilliseconds() );
            var actual = dateTime.IsFuture();
            Assert.IsFalse( actual );

            dateTime = DateTime.Now.AddDays( 2 );
            actual = dateTime.IsFuture();
            Assert.IsTrue( actual );
        }
    }
}