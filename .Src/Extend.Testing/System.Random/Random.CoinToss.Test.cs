#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class RandomExTest
    {
        [Fact]
        public void CoinTossTest()
        {
            var random = new Random();
            var actual = random.CoinToss();

            actual.Should()
                  .Be( actual );
        }

        [Fact]
        public void CoinTossTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomEx.CoinToss( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}