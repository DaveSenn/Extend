#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ExtractTest()
        {
            var actual = "abcabc".Extract( x => x == 'a' );
            Assert.AreEqual( "aa", actual );
        }

        [Test]
        public void ExtractTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.Extract( null, y => false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".Extract( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}