#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsDefaultTestCase()
        {
            var value = default( String );
            var actual = value.IsDefault();
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsDefault();
            Assert.IsFalse( actual );
        }
    }
}