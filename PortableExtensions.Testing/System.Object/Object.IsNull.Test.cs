#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
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