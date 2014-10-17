#region Usings

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IsEmptyTestCase ()
        {
            var value = "";
            Assert.IsTrue( value.IsEmpty() );

            value = null;
            Assert.IsTrue( value.IsEmpty() );

            value = "   ";
            Assert.IsTrue( value.IsEmpty() );

            value = RandomValueEx.GetRandomString();
            Assert.IsFalse( value.IsEmpty() );
        }
    }
}