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
        public void ToCharTestCase()
        {
            var expected = 'a';
            var value = expected.ToString();
            var actual = ObjectEx.ToChar( value );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToCharTestCaseNullCheck()
        {
            ObjectEx.ToChar( null );
        }
    }
}