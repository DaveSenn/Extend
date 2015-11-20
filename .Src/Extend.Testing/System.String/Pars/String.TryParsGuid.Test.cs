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
        public void TryParsGuidTestCase()
        {
            var expected = Guid.NewGuid();
            Guid result;
            var actual = expected.ToString()
                                 .TryParsGuid( out result );

            Assert.AreEqual( expected, result );
            Assert.IsTrue( actual );
        }

        [Test]
        public void TryParsGuidTestCase1()
        {
            var expected = Guid.NewGuid();
            const String input = "NotAGuid";
            Guid result;
            var actual = input
                .TryParsGuid( out result );

            Assert.AreEqual( Guid.Empty, result );
            Assert.IsFalse( actual );
        }

        [Test]
        public void TryParsGuidTestCaseNullCheck()
        {
            const String input = null;
            Guid result;
            Action test = () => input
                .TryParsGuid( out result );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}