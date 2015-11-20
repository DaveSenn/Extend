﻿#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class DoubleExTest
    {
        [Test]
        public void PercentOfTestCase()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Double) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase1DivideByZero()
        {
            Action test = () => DoubleEx.PercentOf( 0, (Double) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCase2()
        {
            Double number = 1000;
            var expected = 50;
            var actual = number.PercentOf( (Int64) 500 );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void PercentOfTestCase2DivideByZero()
        {
            Action test = () => DoubleEx.PercentOf( 0, (Int64) 100 );

            test.ShouldThrow<DivideByZeroException>();
        }

        [Test]
        public void PercentOfTestCaseDivideByZero()
        {
            Action test = () => DoubleEx.PercentOf( 0, 100 );

            test.ShouldThrow<DivideByZeroException>();
        }
    }
}