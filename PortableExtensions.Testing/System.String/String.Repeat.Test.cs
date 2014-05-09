#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void RepeatTestCase()
        {
            var actual = StringEx.Repeat( null, 10 );
            Assert.AreEqual( String.Empty, actual );

            actual = "".Repeat( 10 );
            Assert.AreEqual( String.Empty, actual );

            actual = "a".Repeat( 10 );
            Assert.AreEqual( "aaaaaaaaaa", actual );
        }
    }
}