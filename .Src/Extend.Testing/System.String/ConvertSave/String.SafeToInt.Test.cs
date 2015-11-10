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
        public void SafeToIntTestCase()
        {
            var actual = "1".SafeToInt();
            Assert.AreEqual( 1, actual );

            actual = "1asd".SafeToInt();
            Assert.AreEqual( null, actual );
        }

        [Test]
        public void SafeToIntTestCaseNullCheck()
        {
            Action test = () => StringEx.SafeToInt( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}