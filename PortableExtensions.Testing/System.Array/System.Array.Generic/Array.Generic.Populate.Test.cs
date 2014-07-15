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
        public void PopulateTestCase()
        {
            var array = new Int32[10];
            var actual = array.Populate(100);

            Assert.AreSame(array, actual);
            Assert.AreEqual(10, array.Length);
            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(100, array[i]);
                Assert.AreEqual(100, actual[i]);
            }
        }
    }
}