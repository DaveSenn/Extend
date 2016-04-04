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
        public void SaveToGuidTestCase()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToGuidTestCase1()
        {
            var expected = Guid.NewGuid();
            var actual = "InvalidValue".SaveToGuid( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToGuidTestCase4()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString()
                                 .SaveToGuid( Guid.NewGuid() );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToGuidTestCase5()
        {
            var actual = "InvalidValue".SaveToGuid();

            Assert.AreEqual( default(Guid), actual );
        }

        [Test]
        public void SaveToGuidTestCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.SaveToGuid( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}