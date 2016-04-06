#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IsNotEmptyTest()
        {
            var value = "";
            Assert.IsFalse( value.IsNotEmpty() );

            value = null;
            Assert.IsFalse( value.IsNotEmpty() );

            value = "   ";
            Assert.IsFalse( value.IsNotEmpty() );

            value = RandomValueEx.GetRandomString();
            Assert.IsTrue( value.IsNotEmpty() );
        }
    }
}