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
        public void ToEnumTest()
        {
            const DayOfWeek expected = DayOfWeek.Monday;
            var actual = expected.ToString()
                                 .ToEnum<DayOfWeek>();

            actual
                .Should()
                .Be( expected );
        }

        [Test]
        public void ToEnumTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => StringEx.ToEnum<DayOfWeek>( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}