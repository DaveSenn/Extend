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
        public void KeepLettersAndNumbersTest()
        {
            var actual = "a1b2c3".KeepLettersAndNumbers();
            Assert.AreEqual( "a1b2c3", actual );

            actual = "a1.b2-c3".KeepLettersAndNumbers();
            Assert.AreEqual( "a1b2c3", actual );
        }

        [Test]
        public void KeepLettersAndNumbersTestNullCheck()
        {
            Action test = () => StringEx.KeepLettersAndNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}