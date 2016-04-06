#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void IsEvenTest()
        {
            var value = RandomValueEx.GetRandomInt16();

            var expected = value % 2 == 0;
            var actual = value.IsEven();
            Assert.AreEqual( expected, actual );
        }
    }
}