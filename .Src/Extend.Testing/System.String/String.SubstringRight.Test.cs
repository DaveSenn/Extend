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
        public void SubstringRightTestCase()
        {
            var actual = "testabc".SubstringRight( 3 );
            Assert.AreEqual( "abc", actual );
        }

        [Test]
        public void SubstringRightTestCaseNullCheck()
        {
            Action test = () => StringEx.SubstringRight( null, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}