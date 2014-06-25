#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void SaveToBooleanTestCase()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString().SaveToBoolean();

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        public void SaveToBooleanTestCase1()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToBooleanTestCaseNullCheck()
        {
            StringEx.SaveToBoolean( null );
        }
    }
}