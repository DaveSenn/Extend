#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void AsTestCase()
        {
            Object value = 10;
            var actual = value.As<int>();

            Assert.AreEqual( value, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AsTestCaseNullCheck()
        {
            ObjectEx.As<String>( null );
        }
    }
}