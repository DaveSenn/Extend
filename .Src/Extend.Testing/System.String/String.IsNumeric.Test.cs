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
        public void IsNumericTest()
        {
            var actual = "test".IsNumeric();
            Assert.IsFalse( actual );

            actual = "1test".IsNumeric();
            Assert.IsFalse( actual );

            actual = "123".IsNumeric();
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNumericTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.IsNumeric( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}