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
        public void SaveToBooleanTestCase()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString()
                                 .SaveToBoolean();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanTestCase1()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanTestCase2()
        {
            var actual = true.ToString()
                             .SaveToBoolean( false );

            Assert.AreEqual( true, actual );
        }

        [Test]
        public void SaveToBooleanTestCase3()
        {
            var actual = "InvalidValue".SaveToBoolean();

            Assert.AreEqual( default(Boolean), actual );
        }

        [Test]
        public void SaveToBooleanTestCaseNullCheck()
        {
            Action test = () => StringEx.SaveToBoolean( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}