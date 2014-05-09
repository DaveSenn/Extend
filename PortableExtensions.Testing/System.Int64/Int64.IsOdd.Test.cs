#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [TestCase]
        public void IsOddTestCase()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 != 0;
            var actual = Int64Ex.IsOdd( value );
            Assert.AreEqual( expected, actual );
        }
    }
}