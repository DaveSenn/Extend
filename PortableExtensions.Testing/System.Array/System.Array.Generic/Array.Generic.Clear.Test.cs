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
        public void GenericClearTestCase ()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.Clear( 0, 2 );

            Assert.AreEqual( null, array [0] );
            Assert.AreEqual( null, array [1] );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GenericClearTestCase1 ()
        {
            ArrayEx.Clear<String>( null, 0, 2 );
        }
    }
}