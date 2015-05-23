#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
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