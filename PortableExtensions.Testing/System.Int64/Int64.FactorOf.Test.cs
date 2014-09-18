#region Using

using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void FactorOfTestCase()
        {
            var value = RandomValueEx.GetRandomInt32();
            var factorNumer = RandomValueEx.GetRandomInt32();

            var expected = factorNumer % value == 0;
            var actual = Int64Ex.FactorOf( value, factorNumer );
            Assert.AreEqual( expected, actual );

            value = 10;
            factorNumer = 100;
            expected = true;
            actual = Int64Ex.FactorOf( value, factorNumer );
            Assert.AreEqual( expected, actual );

            value = 11;
            factorNumer = 100;
            expected = false;
            actual = Int64Ex.FactorOf( value, factorNumer );
            Assert.AreEqual( expected, actual );
        }
    }
}