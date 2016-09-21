#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ToSingleItemArrayTest()
        {
            var item = RandomValueEx.GetRandomString();

            var actual = item.ToSingleItemArray();

            Assert.AreEqual( 1, actual.Length );
            Assert.AreEqual( item, actual[0] );
        }
    }
}