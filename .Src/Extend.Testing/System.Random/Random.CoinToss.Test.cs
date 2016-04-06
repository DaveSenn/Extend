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
        }

        [Test]
        public void CoinTossTestNullCheck()
        {
            Action test = () => RandomEx.CoinToss( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}