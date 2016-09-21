#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class IEnumerableStringExTest
    {
        [Test]
        public void PathCombineTest()
        {
            var list = new List<String> { @"C:\", "Temp", "Test", "test.xml" };
            var expected = Path.Combine( list.ToArray() );
            var actual = list.PathCombine();
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PathCombineTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEnumerableStringEx.PathCombine( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}