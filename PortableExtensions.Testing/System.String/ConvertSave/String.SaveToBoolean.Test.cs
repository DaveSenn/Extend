#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void SaveToBooleanTestCase()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = expected.ToString().SaveToBoolean();

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SaveToBooleanTestCase1()
        {
            var expected = RandomValueEx.GetRandomBoolean();
            var actual = "InvalidValue".SaveToBoolean( expected );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void SaveToBooleanTestCaseNullCheck()
        {
            StringEx.SaveToBoolean( null );
        }
    }
}