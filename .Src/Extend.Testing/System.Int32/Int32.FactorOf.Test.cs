#region Usings

using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void FactorOfTestCase()
        {
            var value = RandomValueEx.GetRandomInt32();
            var factorNumer = RandomValueEx.GetRandomInt32();

            var expected = factorNumer % value == 0;
            var actual = value.FactorOf( factorNumer );
            Assert.AreEqual( expected, actual );

            value = 10;
            factorNumer = 100;
            expected = true;
            actual = value.FactorOf( factorNumer );
            Assert.AreEqual( expected, actual );

            value = 11;
            factorNumer = 100;
            expected = false;
            actual = value.FactorOf( factorNumer );
            Assert.AreEqual( expected, actual );
        }
    }
}