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
        public void KeepNumbersTest()
        {
            var actual = "a1b2c3".KeepNumbers();
            Assert.AreEqual( "123", actual );
        }

        [Test]
        public void KeepNumbersTEstCaseNullCheck()
        {
            Action test = () => StringEx.KeepNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}