#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsNullTestCase()
        {
            var value = RandomValueEx.GetRandomString();
            var actual = value.IsNull();

            Assert.IsFalse( actual );

            value = null;
            actual = value.IsNull();

            Assert.IsTrue( actual );
        }
    }
}