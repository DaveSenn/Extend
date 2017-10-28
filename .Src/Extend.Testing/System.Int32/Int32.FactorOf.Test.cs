#region Usings

using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class Int32ExTest
    {
        [Fact]
        public void FactorOfTest()
        {
            var value = RandomValueEx.GetRandomInt32();
            var factorNumer = RandomValueEx.GetRandomInt32();

            var expected = factorNumer % value == 0;
            var actual = value.FactorOf( factorNumer );
            Assert.Equal( expected, actual );

            value = 10;
            factorNumer = 100;
            actual = value.FactorOf( factorNumer );
            Assert.True( actual );

            value = 11;
            factorNumer = 100;
            actual = value.FactorOf( factorNumer );
            Assert.False( actual );
        }
    }
}