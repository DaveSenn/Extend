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
        public void TakeUntilTest()
        {
            var list = new List<String>();
            var result = list.TakeUntil( x => true );
            Assert.Equal( list.Count, result.Count() );

            list = RandomValueEx.GetRandomStrings( 10 );
            result = list.TakeUntil( x => false );
            Assert.Equal( list.Count, result.Count() );

            var counter = 0;
            var resultList = list.TakeUntil( x =>
                                 {
                                     counter++;
                                     return counter > 5;
                                 } )
                                 .ToList();
            Assert.Equal( 5, resultList.Count );

            for ( var i = 0; i < resultList.Count; i++ )
                Assert.Equal( list[i], resultList[i] );
        }

        [Fact]
        public void TakeUntilTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.TakeUntil( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TakeUntilTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().TakeUntil( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}