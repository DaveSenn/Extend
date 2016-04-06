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
        public void IsNumberTest()
        {
            var range = 0.RangeTo( 9 );
            foreach ( var c in range.Select( x => x.ToChar() ) )
                Assert.IsTrue( c.IsNumber() );

            Assert.IsFalse( 'a'.IsNumber() );
            Assert.IsFalse( 'A'.IsNumber() );
            Assert.IsFalse( 'z'.IsNumber() );
            Assert.IsFalse( '-'.IsNumber() );
        }
    }
}