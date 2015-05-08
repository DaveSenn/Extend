#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsNotNullTestCase()
        {
            var value = RandomValueEx.GetRandomString();
            var actual = value.IsNotNull();

            Assert.IsTrue( actual );

            value = null;
            actual = value.IsNotNull();

            Assert.IsFalse( actual );
        }
    }
}