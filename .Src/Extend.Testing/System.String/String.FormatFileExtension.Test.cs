#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void FormatFileExtensionTest()
        {
            var actual = "xml".FormatFileExtension();
            Assert.Equal( ".xml", actual );

            actual = ".xml".FormatFileExtension();
            Assert.Equal( ".xml", actual );
        }

        [Fact]
        public void FormatFileExtensionTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.FormatFileExtension( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FormatFileExtensionTestNullCheckArgumentException()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => String.Empty.FormatFileExtension();

            test.ShouldThrow<ArgumentException>();
        }
    }
}