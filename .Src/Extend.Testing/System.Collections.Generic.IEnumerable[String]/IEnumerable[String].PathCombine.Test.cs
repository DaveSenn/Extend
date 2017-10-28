#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public class IEnumerableStringExTest
    {
        [Fact]
        public void PathCombineTest()
        {
            var list = new List<String> { @"C:\", "Temp", "Test", "test.xml" };
            var expected = Path.Combine( list.ToArray() );
            var actual = list.PathCombine();
            Assert.Equal( expected, actual );
        }

        [Fact]
        public void PathCombineTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEnumerableStringEx.PathCombine( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}