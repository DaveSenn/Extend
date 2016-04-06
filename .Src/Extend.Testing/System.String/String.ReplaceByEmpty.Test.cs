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
        public void ReplaceByEmptyTest()
        {
            var actual = "abcd".ReplaceByEmpty( "a", "c" );
            Assert.AreEqual( "bd", actual );
        }

        [Test]
        public void ReplaceByEmptyTestNullCheck()
        {
            Action test = () => StringEx.ReplaceByEmpty( null, "a", "c" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ReplaceByEmptyTestNullCheck1()
        {
            Action test = () => "".ReplaceByEmpty( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}