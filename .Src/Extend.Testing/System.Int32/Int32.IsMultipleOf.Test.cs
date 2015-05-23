#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void IsMultipleOfTestCase()
        {
            var value = RandomValueEx.GetRandomInt32();
            var factor = RandomValueEx.GetRandomInt32();

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