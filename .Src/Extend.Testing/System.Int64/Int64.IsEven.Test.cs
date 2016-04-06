#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void IsEvenTest()
        {
            var value = RandomValueEx.GetRandomInt32();

            var expected = value % 2 == 0;
            var actual = Int64Ex.IsEven( value );
            Assert.AreEqual( expected, actual );
        }
    }
}