#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [TestCase]
        public void GenericResizeTestCase()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array = array.Resize( 10 );
            Assert.AreEqual( 10, array.Length );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericResizeTestCaseNullCheck()
        {
            String[] array = null;
            array = array.Resize( 10 );
            Assert.AreEqual( 10, array.Length );
        }
    }
}