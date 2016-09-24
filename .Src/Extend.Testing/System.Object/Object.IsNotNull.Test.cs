#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsNotNullTest()
        {
            var value = RandomValueEx.GetRandomString();
            var actual = value.IsNotNull();

            Assert.IsTrue( actual );

            value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            actual = value.IsNotNull();

            Assert.IsFalse( actual );
        }
    }
}