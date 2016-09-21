#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void StringJoinCollectionNull()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void StringJoinNullSeperatorTest()
        {
            var list = new List<String> { "1", "2", "3" };
            var actual = list.StringJoin( null );

            actual
                .Should()
                .Be( "123" );
        }

        [Test]
        public void StringJoinSelectorCollectionNullTEst()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin( x => x.ToString() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void StringJoinSelectorNullSeperatorTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            var actual = list.StringJoin( x => x.ToString() + "!", null );

            actual
                .Should()
                .Be( "1!2!3!" );
        }

        [Test]
        public void StringJoinSelectorNullTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.StringJoin( null, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void StringJoinSelectorTest()
        {
            var list = new List<Int32> { 1, 2, 3 };
            var actual = list.StringJoin( x => x.ToString() + "!", "," );

            actual
                .Should()
                .Be( "1!,2!,3!" );
        }

        [Test]
        public void StringJoinTest()
        {
            var list = new List<String>();
            var actual = list.StringJoin( "," );
            Assert.AreEqual( String.Empty, actual );

            actual = list.StringJoin();
            Assert.AreEqual( String.Empty, actual );

            list = RandomValueEx.GetRandomStrings();
            actual = list.StringJoin( "," );
            var expected = String.Join( ",", list );
            Assert.AreEqual( expected, actual );

            actual = list.StringJoin();
            expected = String.Join( "", list );
            Assert.AreEqual( expected, actual );
        }
    }
}