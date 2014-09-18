#region Using

using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void IsDigitTestCase()
        {
            var range = 0.RangeTo( 9 );
            foreach ( var c in range.Select( x => x.ToChar() ) )
                Assert.IsTrue( c.IsDigit() );

            Assert.IsFalse( 'a'.IsDigit() );
            Assert.IsFalse( 'A'.IsDigit() );
            Assert.IsFalse( 'z'.IsDigit() );
            Assert.IsFalse( '-'.IsDigit() );
        }
    }
}