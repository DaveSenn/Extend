#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void IfNullTestCase()
        {
            var expected = RandomValueEx.GetRandomString();

            var actual = ObjectEx.IfNull( null, expected );
            Assert.AreEqual( expected, actual );

            actual = expected.IfNull( null );
            Assert.AreEqual( expected, actual );
        }
    }
}