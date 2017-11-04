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
        public void ToObservableCollectionTest()
        {
            var list = RandomValueEx.GetRandomStrings();
            var actual = list.ToObservableCollection();

            Assert.Equal( list.Count, actual.Count );
            for ( var i = 0; i < list.Count; i++ )
                Assert.Equal( list[i], actual[i] );
        }

        [Fact]
        public void ToObservableCollectionTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ToObservableCollection();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}