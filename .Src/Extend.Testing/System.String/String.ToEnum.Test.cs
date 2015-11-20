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
        public void ToEnumTestCase()
        {
            var expected = DayOfWeek.Monday;
            var actual = expected.ToString()
                                 .ToEnum<DayOfWeek>();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void ToEnumTestCaseNullCheck()
        {
            Action test = () => StringEx.ToEnum<DayOfWeek>( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}