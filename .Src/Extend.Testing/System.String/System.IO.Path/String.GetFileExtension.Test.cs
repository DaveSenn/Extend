#region Usings

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
        public void GetFileExtensionTest()
        {
            const String fielName = "test.txt";
            var expected = Path.GetExtension( fielName );
            var actual = fielName.GetFileExtension();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void GetFileExtensionTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.GetFileExtension( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}