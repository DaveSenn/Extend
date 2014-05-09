#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void TryToEnumTestCase()
        {
            var expected = DayOfWeek.Monday;
            var actual = DayOfWeek.Saturday;
            var result = StringEx.TryToEnum( expected.ToString(), out actual );

            Assert.AreEqual( expected, actual );
            Assert.IsTrue( result );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void TryToEnumTestCaseNullCheck()
        {
            var day = DayOfWeek.Saturday;
            StringEx.TryToEnum( null, out day );
        }
    }
}