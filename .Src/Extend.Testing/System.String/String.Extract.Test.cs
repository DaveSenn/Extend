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
        public void ExtractTestCase()
        {
            var actual = "abcabc".Extract( x => x == 'a' );
            Assert.AreEqual( "aa", actual );
        }

        [Test]
        public void ExtractTestCaseNullCheck()
        {
            Action test = () => StringEx.Extract( null, y => false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ExtractTestCaseNullCheck1()
        {
            Action test = () => "".Extract( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}