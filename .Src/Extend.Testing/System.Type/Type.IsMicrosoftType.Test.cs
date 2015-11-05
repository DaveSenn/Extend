#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void IsMicrosoftTypeTest()
        {
            var type = typeof (String);
            var actual = type.IsMicrosoftType();

            Assert.IsTrue( actual );
        }

        [Test]
        public void IsMicrosoftTypeTest1()
        {
            var type = typeof (TypeExTest);
            var actual = type.IsMicrosoftType();

            Assert.IsFalse( actual );
        }
    }
}