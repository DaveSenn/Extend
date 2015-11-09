﻿#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void WithinIndexTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };

            var actual = array.WithinIndex( 2 );
            Assert.IsTrue( actual );

            actual = array.WithinIndex( -1 );
            Assert.IsFalse( actual );

            actual = array.WithinIndex( 5 );
            Assert.IsFalse( actual );
        }

        [Test]
        public void WithinIndexTestCaseNullCheck()
        {
            Array array = null;
            Action test = () => array.WithinIndex( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}