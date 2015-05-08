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
        public void AsTestCase()
        {
            Object value = 10;
            var actual = value.As<int>();

            Assert.AreEqual( value, actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AsTestCaseNullCheck()
        {
            ObjectEx.As<String>( null );
        }
    }
}