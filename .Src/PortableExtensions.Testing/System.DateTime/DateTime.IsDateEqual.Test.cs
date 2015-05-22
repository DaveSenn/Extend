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
        public void IsDateEqualTestCase()
        {
            var dateTime = new DateTime( 2014, 10, 10, 13, 0, 0 );
            var dateTime1 = new DateTime( 2014, 10, 10, 06, 0, 0 );
            var actual = dateTime.IsDateEqual( dateTime1 );
            Assert.IsTrue( actual );

            dateTime = new DateTime( 2014, 10, 10, 13, 0, 0 );
            dateTime1 = new DateTime( 2014, 11, 10, 06, 0, 0 );
            actual = dateTime.IsDateEqual( dateTime1 );
            Assert.IsFalse( actual );
        }
    }
}