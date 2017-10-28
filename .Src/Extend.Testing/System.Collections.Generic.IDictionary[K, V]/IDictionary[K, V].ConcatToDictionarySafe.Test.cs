#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Fact]
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
            Assert.Equal( 4, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Fact]
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
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Fact]
        public void ConcatToDictionarySafeTest2()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var first = new Dictionary<Int32, Int32>();
            // ReSharper disable once CollectionNeverUpdated.Local
            var second = new Dictionary<Int32, Int32>();

            var actual = first.ConcatToDictionarySafe( second );
            Assert.Equal( 0, actual.Count );
        }

        [Fact]
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
            Assert.Equal( 4, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Fact]
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

        [Fact]
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