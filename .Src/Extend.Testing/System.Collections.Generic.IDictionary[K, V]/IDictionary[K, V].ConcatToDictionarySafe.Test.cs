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
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Test]
        public void ConcatToDictionarySafeTest()
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
        public void ConcatToDictionarySafeTest1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            // ReSharper disable once CollectionNeverUpdated.Local
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.AreEqual( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Test]
        public void ConcatToDictionarySafeTest2()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var first = new Dictionary<Int32, Int32>();
            // ReSharper disable once CollectionNeverUpdated.Local
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionarySafe( second );
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void ConcatToDictionarySafeTest3()
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
        public void ConcatToDictionarySafeTestNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32> second = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => first.ConcatToDictionarySafe( second );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ConcatToDictionarySafeTestNullCheck1()
        {
            Dictionary<Int32, Int32> first = null;
            var second = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => first.ConcatToDictionarySafe( second );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}