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
        public void RemoveNumbersTest()
        {
            var actual = "a1-b2.c3".RemoveNumbers();
            Assert.AreEqual( "a-b.c", actual );
        }

        [Test]
        public void RemoveNumbersTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.RemoveNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}