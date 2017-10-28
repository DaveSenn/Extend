#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void StringJoinCollectionNull()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StringJoinNullSeperatorTest()
        {
            var list = new List<String> { "1", "2", "3" };
            var actual = list.StringJoin( null );

            actual
                .Should()
                .Be( "123" );
        }

        [Fact]
        public void StringJoinSelectorCollectionNullTEst()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin( x => x.ToString() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StringJoinSelectorNullSeperatorTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            var actual = list.StringJoin( x => x.ToString() + "!", null );

            actual
                .Should()
                .Be( "1!2!3!" );
        }

        [Fact]
        public void StringJoinSelectorNullTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin( null, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StringJoinSelectorTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            var actual = list.StringJoin( x => x.ToString() + "!", "," );

            actual
                .Should()
                .Be( "1!,2!,3!" );
        }

        [Fact]
        public void StringJoinTest()
        {
            var list = new List<String>();
            var actual = list.StringJoin( "," );
            Assert.Equal( String.Empty, actual );

            actual = list.StringJoin();
            Assert.Equal( String.Empty, actual );

            list = RandomValueEx.GetRandomStrings();
            actual = list.StringJoin( "," );
            var expected = String.Join( ",", list );
            Assert.Equal( expected, actual );

            actual = list.StringJoin();
            expected = String.Join( "", list );
            Assert.Equal( expected, actual );
        }
    }
}