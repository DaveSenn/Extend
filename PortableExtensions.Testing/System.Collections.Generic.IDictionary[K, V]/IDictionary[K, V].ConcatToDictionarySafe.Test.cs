#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        public void ConcatToDictionarySafeTestCase()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var second = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatToDictionarySafeTestCase1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Test]
        public void ConcatToDictionarySafeTestCase2()
        {
            var first = new Dictionary<Int32, Int32>();
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void ConcatToDictionarySafeTestCase3()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var second = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 },
                { 2, 3 },
                { 3, 4 }
            };

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ConcatToDictionarySafeTestCaseNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32> second = null;

            first.ConcatToDictionarySafe( second );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ConcatToDictionarySafeTestCaseNullCheck1()
        {
            Dictionary<Int32, Int32> first = null;
            var second = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };

            first.ConcatToDictionarySafe( second );
        }
    }
}