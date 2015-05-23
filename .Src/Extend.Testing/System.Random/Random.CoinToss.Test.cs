#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [Test]
        public void CoinTossTestCase()
        {
            var random = new Random();
            var actual = random.CoinToss();
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void CoinTossTestCaseNullCheck()
        {
            RandomEx.CoinToss( null );
        }
    }
}