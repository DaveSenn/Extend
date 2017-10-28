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
        public void ConcatAllToDictionarySafeTest()
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
            Assert.Equal( 6, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 4 && x.Value == 5 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 5 && x.Value == 6 ) );
        }

        [Fact]
        public void ConcatAllToDictionarySafeTest1()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            var other1 = new Dictionary<Int32, Int32>();
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
        }

        [Fact]
        public void ConcatAllToDictionarySafeTest2()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            var other2 = new Dictionary<Int32, Int32>();

            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Fact]
        public void ConcatAllToDictionarySafeTest3()
        {
            var first = new Dictionary<Int32, Int32>();
            var other1 = new Dictionary<Int32, Int32>
            {
                { 2, 3 },
                { 3, 4 }
            };
            Dictionary<Int32, Int32> other2 = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = first.ConcatAllToDictionarySafe( other1, other2 );
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
        }

        [Fact]
        public void ConcatAllToDictionarySafeTest4()
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
            Assert.Equal( 6, actual.Count );
            Assert.Equal( 1, actual.Count( x => x.Key == 0 && x.Value == 1 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 1 && x.Value == 2 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 2 && x.Value == 3 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 3 && x.Value == 4 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 4 && x.Value == 5 ) );
            Assert.Equal( 1, actual.Count( x => x.Key == 5 && x.Value == 6 ) );
        }

        [Fact]
        public void ConcatAllToDictionarySafeTestNullCheck()
        {
            var first = new Dictionary<Int32, Int32>
            {
                { 0, 1 },
                { 1, 2 }
            };
            Dictionary<Int32, Int32>[] others = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once CoVariantArrayConversion
            Action test = () => first.ConcatAllToDictionarySafe( others );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ConcatAllToDictionarySafeTestNullCheck1()
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

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => first.ConcatAllToDictionarySafe( other1, other2 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}