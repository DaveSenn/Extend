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
        public void GenericClearAllTestCase()
        {
            var array = new[]
            {
                "test",
                "test"
            };
            array.ClearAll();

            Assert.AreEqual( null, array[0] );
            Assert.AreEqual( null, array[1] );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GenericClearAllTestCase1()
        {
            String[] array = null;
            array.ClearAll();
        }
    }
}