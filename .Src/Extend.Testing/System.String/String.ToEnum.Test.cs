#region Usings

using System;
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToEnumTestCaseNullCheck()
        {
            StringEx.ToEnum<DayOfWeek>( null );
        }
    }
}