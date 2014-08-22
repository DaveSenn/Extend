#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void CountOptimiseTestCase()
        {
            var list = new List<String> { "test", "test1" };

            var actual = list.CountOptimized();
            Assert.AreEqual( 2, actual );
        }

        [TestCase]
        public void CountOptimiseTestCase1()
        {
            var list = new List<String>();

            var actual = list.CountOptimized();
            Assert.AreEqual( 0, actual );
        }

        [TestCase]
        public void CountOptimiseTestCase2()
        {
            var array = new[]
            {
                "test",
                "test1",
                "test3"
            };

            var actual = array.CountOptimized();
            Assert.AreEqual( 3, actual );
        }

        [TestCase]
        public void CountOptimiseTestCase3()
        {
            var array = new String[]
            {
            };

            var actual = array.CountOptimized();
            Assert.AreEqual( 0, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CountOptimiseTestCaseNullCheck()
        {
            List<String> list = null;

            list.CountOptimized();
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CountOptimiseTestCaseNullCheck1()
        {
            String[] array = null;

            array.CountOptimized();
        }
    }
}