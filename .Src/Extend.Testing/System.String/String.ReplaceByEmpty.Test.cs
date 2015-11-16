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
        public void ReplaceByEmptyTestCase()
        {
            var actual = "abcd".ReplaceByEmpty( "a", "c" );
            Assert.AreEqual( "bd", actual );
        }

        [Test]
        public void ReplaceByEmptyTestCaseNullCheck()
        {
            Action test = () => StringEx.ReplaceByEmpty( null, "a", "c" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ReplaceByEmptyTestCaseNullCheck1()
        {
            Action test = () => "".ReplaceByEmpty( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}