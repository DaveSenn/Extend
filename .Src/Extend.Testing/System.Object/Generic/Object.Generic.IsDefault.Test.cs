#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsDefaultTest()
        {
            var value = default(String);
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = value.IsDefault();
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsDefault();
            Assert.IsFalse( actual );
        }
    }
}