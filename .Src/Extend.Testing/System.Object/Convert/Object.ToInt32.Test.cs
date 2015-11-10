﻿#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToInt32TestCase()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt32( value );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt32TestCase1()
        {
            var expected = RandomValueEx.GetRandomInt32();
            var value = expected.ToString();
            var actual = ObjectEx.ToInt32( value, CultureInfo.InvariantCulture );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToInt32TestCase1NullCheck()
        {
            Action test = () => ObjectEx.ToInt32( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt32TestCase1NullCheck1()
        {
            Action test = () => ObjectEx.ToInt32( "false", null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt32TestCaseNullCheck()
        {
            Action test = () => ObjectEx.ToInt32( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}