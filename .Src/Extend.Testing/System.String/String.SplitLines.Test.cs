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
        public void SplitLinesTestCase()
        {
            var value = "test";

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );
        }

        [Test]
        public void SplitLinesTestCase1()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines( StringSplitOptions.RemoveEmptyEntries );
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );

            actual = value.SplitLines( StringSplitOptions.None );
            Assert.AreEqual( 4, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );
            Assert.AreEqual( String.Empty, actual[2] );
            Assert.AreEqual( String.Empty, actual[3] );
        }

        [Test]
        public void SplitLinesTestCase2()
        {
            var value = "test";

            var actual = value.SplitLines();
            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( value, actual[0] );
        }

        [Test]
        public void SplitLinesTestCase2NullCheck()
        {
            String value = null;
            Action test = () => value.SplitLines();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SplitLinesTestCase3()
        {
            var value = "test{0}test{0}{0}".F( Environment.NewLine );

            var actual = value.SplitLines();
            Assert.AreEqual( 2, actual.Length );
            Assert.AreEqual( "test", actual[0] );
            Assert.AreEqual( "test", actual[1] );
        }

        [Test]
        public void SplitLinesTestCaseNullCheck()
        {
            String value = null;

            Action test = () => value.SplitLines( StringSplitOptions.RemoveEmptyEntries );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SplitLinesTestCaseNullCheck1()
        {
            String value = null;

            Action test = () => value.SplitLines( StringSplitOptions.None );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}