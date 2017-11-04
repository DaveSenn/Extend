#region Usings

using System;
using System.IO;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class StringExTest
    {
        [Fact]
        public void GetFileExtensionTest()
        {
            const String fielName = "test.txt";
            var expected = Path.GetExtension( fielName );
            var actual = fielName.GetFileExtension();

            Assert.Equal( expected, actual );
        }

        [Fact]
        public void GetFileExtensionTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetFileExtension( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}