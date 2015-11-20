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
        public void IsAlphaTestCase()
        {
            var actual = "test".IsAlpha();
            Assert.IsTrue( actual );

            actual = "1test".IsAlpha();
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsAlphaTestCaseNullCheck()
        {
            Action test = () => StringEx.IsAlpha( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}