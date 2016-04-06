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
        public void ExtractLettersTest()
        {
            var actual = "1a2b3c4".ExtractLetters();
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        public void ExtractLettersTestNullCheck()
        {
            Action test = () => StringEx.ExtractLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}