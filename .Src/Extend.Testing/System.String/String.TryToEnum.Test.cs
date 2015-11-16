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
        public void TryToEnumTestCase()
        {
            var expected = DayOfWeek.Monday;
            var actual = DayOfWeek.Saturday;
            var result = StringEx.TryToEnum( expected.ToString(), out actual );

            Assert.AreEqual( expected, actual );
            Assert.IsTrue( result );
        }

        [Test]
        public void TryToEnumTestCaseNullCheck()
        {
            var day = DayOfWeek.Saturday;
            Action test = () => StringEx.TryToEnum( null, out day );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}