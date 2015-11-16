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
        public void SubstringRightSafeTestCase()
        {
            var actual = "testabc".SubstringRightSafe( 3 );
            Assert.AreEqual( "abc", actual );

            actual = "testabc".SubstringRightSafe( 300 );
            Assert.AreEqual( "testabc", actual );

            actual = "".SubstringRightSafe( 300 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void SubstringRightSafeTestCaseNullCheck()
        {
            Action test = () => StringEx.SubstringRight( null, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}