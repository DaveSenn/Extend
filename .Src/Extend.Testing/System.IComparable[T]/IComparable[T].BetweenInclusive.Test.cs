﻿#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [Test]
        public void BetweenInclusiveTestCase()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 300;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );
        }

        [Test]
        public void BetweenInclusiveTestCase1()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );
        }

        [Test]
        public void BetweenInclusiveTestCase2()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 99;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTestCase3()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTestCase4()
        {
            const Int32 value = 2;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTestCaseNullCheck()
        {
            Action test = () => IComparableTEx.BetweenInclusive( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenInclusiveTestCaseNullCheck1()
        {
            Action test = () => "".BetweenInclusive( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenInclusiveTestCaseNullCheck2()
        {
            Action test = () => "".BetweenInclusive( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}