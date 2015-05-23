#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ClearTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Clear( 0, 2 );

            Assert.AreEqual( null, array.GetValue( 0 ) );
            Assert.AreEqual( null, array.GetValue( 1 ) );
            Assert.AreEqual( "2", array.GetValue( 2 ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ClearTestCaseNullCheck()
        {
            Array array = null;
            array.Clear( 0, 0 );
        }
    }
}