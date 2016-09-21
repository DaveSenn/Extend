#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void IsEmptyTest()
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