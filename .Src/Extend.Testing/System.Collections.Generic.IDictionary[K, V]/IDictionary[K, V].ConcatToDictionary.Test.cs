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
        public void ConcatToDictionaryTest()
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

            var actual = first.ConcatToDictionary( second );
            Assert.AreEqual( 4, actual.Count );
            Assert.AreEqual( 2, first.Count );
            Assert.AreEqual( 2, second.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Test]
        public void ConcatToDictionaryTest1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionary( second );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Test]
        public void ConcatToDictionaryTest2()
        {
            var first = new Dictionary<Int32, Int32>();
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionary( second );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void ConcatToDictionaryTestDuplicatedKeys()
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

            Action test = () => first.ConcatToDictionary( second );

            test.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ConcatToDictionaryTestNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32> second = null;

            Action test = () => first.ConcatToDictionary( second );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatToDictionaryTestNullCheck1()
        {
            Dictionary<Int32, Int32> first = null;
            var second = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };

            Action test = () => first.ConcatToDictionary( second );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}