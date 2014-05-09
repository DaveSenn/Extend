#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [TestCase]
        public void CoinTossTestCase()
        {
            var random = new Random();
            var actual = random.CoinToss();
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CoinTossTestCaseNullCheck()
        {
            RandomEx.CoinToss( null );
        }
    }
}