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
        public void KeepLettersTest()
        {
            var actual = "a1b2c3".KeepLetters();
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        public void KeepLettersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.KeepLetters( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}