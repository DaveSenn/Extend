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
        public void RemoveLettersTest()
        {
            var actual = "a1-b2.c3".RemoveLetters();
            Assert.AreEqual( "1-2.3", actual );
        }

        [Test]
        public void RemoveLettersTestNullCheck()
        {
            Action test = () => StringEx.RemoveLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}