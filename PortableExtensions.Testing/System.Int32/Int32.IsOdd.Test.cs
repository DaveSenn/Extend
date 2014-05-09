#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [TestCase]
        public void IsOddTestCase()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 != 0;
            var actual = value.IsOdd();
            Assert.AreEqual( expected, actual );
        }
    }
}