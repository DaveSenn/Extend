#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void IsOddTest()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 != 0;
            var actual = Int64Ex.IsOdd( value );
            Assert.AreEqual( expected, actual );
        }
    }
}