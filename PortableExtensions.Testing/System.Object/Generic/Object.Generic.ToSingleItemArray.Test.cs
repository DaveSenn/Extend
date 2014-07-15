#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToSingleItemArrayTestCase()
        {
            var item = RandomValueEx.GetRandomString();

            var actual = item.ToSingleItemArray();

            Assert.AreEqual(1, actual.Length);
            Assert.AreEqual(item, actual[0]);
        }
    }
}