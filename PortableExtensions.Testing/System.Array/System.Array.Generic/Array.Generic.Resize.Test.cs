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
        public void GenericResizeTestCase ()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array = array.Resize( 10 );
            Assert.AreEqual( 10, array.Length );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void GenericResizeTestCaseNullCheck ()
        {
            String[] array = null;
            array = array.Resize( 10 );
            Assert.AreEqual( 10, array.Length );
        }
    }
}