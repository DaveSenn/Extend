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
        public void ReverseTest()
        {
            var actual = "abc".Reverse();
            Assert.AreEqual( "cba", actual );
        }

        [Test]
        public void ReverseTest1()
        {
            var actual = "a".Reverse();
            Assert.AreEqual( "a", actual );
        }

        [Test]
        public void ReverseTest2()
        {
            var actual = "".Reverse();
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void ReverseTestNullCheck()
        {
            Action test = () => StringEx.Reverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}