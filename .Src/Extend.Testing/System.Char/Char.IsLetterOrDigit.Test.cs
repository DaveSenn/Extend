#region Usings

using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CharExTest
    {
        [Test]
        public void IsLetterOrDigitTest()
        {
            var range = 0.RangeTo( 9 );
            foreach ( var c in range.Select( x => x.ToChar() ) )
                Assert.IsTrue( c.IsLetterOrDigit() );

            Assert.IsTrue( 'a'.IsLetterOrDigit() );
            Assert.IsTrue( 'A'.IsLetterOrDigit() );
            Assert.IsTrue( 'z'.IsLetterOrDigit() );
            Assert.IsFalse( '-'.IsLetterOrDigit() );
        }
    }
}