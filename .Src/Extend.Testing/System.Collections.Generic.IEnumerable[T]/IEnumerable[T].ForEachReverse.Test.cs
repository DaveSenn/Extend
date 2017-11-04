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
        public void ForEachReverseTest()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            list.ForEachReverse( otherList.Add );
            Assert.Equal( list.Count, otherList.Count );
            Assert.True( list.All( x => otherList.Contains( x ) ) );
        }

        [Fact]
        public void ForEachReverseTest1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            list.ForEachReverse( x => list.Remove( x ) );
            Assert.Empty( list );
        }

        [Fact]
        public void ForEachReverseTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ForEachReverse( Console.WriteLine );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ForEachReverseTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ForEachReverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}