#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void GenericToListTestCase()
        {
            var array = new[]
            {
                1, 2, 3
            };
            var list = array.ToGenericList(x => 10 + x);

            Assert.AreEqual(11, list[0]);
            Assert.AreEqual(12, list[1]);
            Assert.AreEqual(13, list[2]);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GenericToListTestCaseNullCheck()
        {
            String[] array = null;
            array.ToGenericList(x => x + "Test");
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GenericToListTestCaseNullCheck1()
        {
            var array = new[]
            {
                1, 2, 3
            };
            Func<Int32, Int32> selector = null;
            array.ToGenericList(selector);
        }
    }
}