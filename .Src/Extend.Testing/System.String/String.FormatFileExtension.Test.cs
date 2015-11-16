#region Usings

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
        public void FormatFileExtensionTestCase()
        {
            var actual = "xml".FormatFileExtension();
            Assert.AreEqual( ".xml", actual );

            actual = ".xml".FormatFileExtension();
            Assert.AreEqual( ".xml", actual );
        }

        [Test]
        public void FormatFileExtensionTestCaseNullCheck()
        {
            Action test = () => StringEx.FormatFileExtension( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void FormatFileExtensionTestCaseNullCheckArgumentException()
        {
            Action test = () => String.Empty.FormatFileExtension();

            test.ShouldThrow<ArgumentException>();
        }
    }
}