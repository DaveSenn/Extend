#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        public void ConcatAllToDictionaryTestCase()
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

            var actual = first.ConcatAllToDictionary( other1, other2 );
            Assert.AreEqual( 6, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 4 && x.Value == 5 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 5 && x.Value == 6 ) );
        }

        [Test]
        public void ConcatAllToDictionaryTestCase1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var other1 = new Dictionary<Int32, Int32>();
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionary( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Test]
        public void ConcatAllToDictionaryTestCase2()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionary( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatAllToDictionaryTestCase3()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            Dictionary<Int32, Int32> other2 = null;

            var actual = first.ConcatAllToDictionary( other1, other2 );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatAllToDictionaryTestCaseDuplicatedKeys()
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
                { 3, 4 }
            };

            Action test = () => first.ConcatAllToDictionary( other1, other2 );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ConcatAllToDictionaryTestCaseNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32>[] others = null;

            Action test = () => first.ConcatAllToDictionary( others );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatAllToDictionaryTestCaseNullCheck1()
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

            Action test = () => first.ConcatAllToDictionary( other1, other2 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}