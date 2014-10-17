#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void JuneTestCase ()
        {
            var expected = new DateTime( 2000, 6, 10 );
            var actual = 10.June( 2000 );
            Assert.AreEqual( expected, actual );
        }
    }
}