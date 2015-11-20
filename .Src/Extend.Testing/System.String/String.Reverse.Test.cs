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
        public void ReverseTestCase()
        {
            var actual = "abc".Reverse();
            Assert.AreEqual( "cba", actual );
        }

        [Test]
        public void ReverseTestCase1()
        {
            var actual = "a".Reverse();
            Assert.AreEqual( "a", actual );
        }

        [Test]
        public void ReverseTestCase2()
        {
            var actual = "".Reverse();
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void ReverseTestCaseNullCheck()
        {
            Action test = () => StringEx.Reverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}