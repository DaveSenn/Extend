﻿#region Usings

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
        public void IsAlphaNumericTestCase()
        {
            var actual = "test".IsAlphaNumeric();
            Assert.IsTrue( actual );

            actual = "1test".IsAlphaNumeric();
            Assert.IsTrue( actual );

            actual = "1te-st".IsAlphaNumeric();
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsAlphaNumericTestCaseNullCheck()
        {
            Action test = () => StringEx.IsAlphaNumeric( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}