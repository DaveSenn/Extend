#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void IsMultipleOfTestCase()
        {
            var value = RandomValueEx.GetRandomInt16();
            var factor = RandomValueEx.GetRandomInt16();

            var expected = value % factor == 0;
            var actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );

            value = 10;
            factor = 2;

            expected = true;
            actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );

            value = 10;
            factor = 3;

            expected = false;
            actual = value.IsMultipleOf( factor );
            Assert.AreEqual( expected, actual );
        }
    }
}