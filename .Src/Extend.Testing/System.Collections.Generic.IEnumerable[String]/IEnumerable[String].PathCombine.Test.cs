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
            Action test = () => IEnumerableStringEx.PathCombine( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}