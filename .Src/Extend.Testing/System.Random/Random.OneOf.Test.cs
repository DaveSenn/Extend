#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [Test]
        public void RandomOneTestCase()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings()
                                    .ToArray();

            var actual = random.RandomOne( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [Test]
        public void RandomOneTestCase1()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings();

            var actual = random.RandomOne<string>( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RandomOneTestCase1NullCheck()
        {
            RandomEx.RandomOne( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RandomOneTestCase1NullCheck1()
        {
            List<String> list = null;
            new Random().RandomOne<string>( list );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RandomOneTestCaseNullCheck()
        {
            RandomEx.RandomOne( null, "", "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RandomOneTestCaseNullCheck1()
        {
            String[] array = null;
            new Random().RandomOne( array );
        }
    }
}