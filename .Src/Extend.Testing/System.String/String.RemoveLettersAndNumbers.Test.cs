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
        public void RemoveLettersAndNumbersTestCase()
        {
            var actual = "a1-b2.c3".RemoveLettersAndNumbers();
            Assert.AreEqual( "-.", actual );
        }

        [Test]
        public void RemoveLettersAndNumbersTestCaseNullCheck()
        {
            Action test = () => StringEx.RemoveLettersAndNumbers( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}