#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        public void ConcatAllToDictionarySafeTestCase()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>
            {
                { 4, 5 },
                { 5, 6 }
            };

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.AreEqual( 6, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 4 && x.Value == 5 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 5 && x.Value == 6 ) );
        }

        [Test]
        public void ConcatAllToDictionarySafeTestCase1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var other1 = new Dictionary<Int32, Int32>();
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Test]
        public void ConcatAllToDictionarySafeTestCase2()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatAllToDictionarySafeTestCase3()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            Dictionary<Int32, Int32> other2 = null;

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatAllToDictionarySafeTestCase4()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 6 }
            };

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.AreEqual( 6, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 4 && x.Value == 5 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 5 && x.Value == 6 ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ConcatAllToDictionarySafeTestCaseNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32>[] others = null;

            first.ConcatAllToDictionarySafe( others );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ConcatAllToDictionarySafeTestCaseNullCheck1()
        {
            Dictionary<Int32, Int32> first = null;
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>
            {
                { 4, 5 },
                { 5, 6 }
            };

            first.ConcatAllToDictionarySafe( other1, other2 );
        }
    }
}