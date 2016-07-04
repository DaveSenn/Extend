#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [Test]
        public void CoinTossTest()
        {
            var random = new Random();
            var actual = random.CoinToss();

            actual.Should()
                  .Be( actual );
        }

        [Test]
        public void CoinTossTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomEx.CoinToss( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}