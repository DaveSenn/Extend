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
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void ForEachTest()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            var actual = IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.Same( list, actual );
            Assert.Equal( list.Count, otherList.Count );
            Assert.True( list.All( otherList.Contains ) );
        }

        [Fact]
        public void ForEachTest1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEnumerableTEx.ForEach( list, x => list.Remove( x ) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ForEachTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ForEach( ( x, i ) => { } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ForEachTest1NullCheck1()
        {
            Action<Object, Int32> action = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ForEach( action );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ForEachTest2()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            var actual = IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.Same( list, actual );
            Assert.Equal( list.Count, otherList.Count );
            Assert.True( list.All( otherList.Contains ) );
        }

        [Fact]
        public void ForEachTest3()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ForEach( ( x, i ) => list.Remove( x ) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ForEachTest4()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var total = 0;
            var actual = list.ForEach( ( x, i ) => total += i );

            Assert.Same( list, actual );
            Assert.Equal( 45, total );
        }

        [Fact]
        public void ForEachTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ForEach( list, Console.WriteLine );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ForEachTestNullCheck1()
        {
            Action<Object> action = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ForEach( new List<Object>(), action );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}