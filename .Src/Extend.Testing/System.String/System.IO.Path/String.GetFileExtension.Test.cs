﻿#region Usings

using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void GetFileExtensionTestCase()
        {
            var fielName = "test.txt";
            var expected = Path.GetExtension( fielName );
            var actual = fielName.GetFileExtension();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void GetFileExtensionTestCaseNullCheck()
        {
            Action test = () => StringEx.GetFileExtension( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}