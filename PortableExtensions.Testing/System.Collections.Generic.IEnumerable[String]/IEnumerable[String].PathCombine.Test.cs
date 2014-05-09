#region Using

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class IEnumerableStringExTest
    {
        [TestCase]
        public void PathCombineTestCase()
        {
            var list = new List<String> { @"C:\", "Temp", "Test", "test.xml" };
            var expected = Path.Combine( list.ToArray() );
            var actual = list.PathCombine();
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void PathCombineTestCaseNullCheck()
        {
            IEnumerableStringEx.PathCombine( null );
        }
    }
}