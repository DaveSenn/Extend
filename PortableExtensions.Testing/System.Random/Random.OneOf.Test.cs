#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [TestCase]
        public void RandomOneTestCase()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings().ToArray();

            var actual = random.RandomOne( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RandomOneTestCaseNullCheck()
        {
            RandomEx.RandomOne( null, "", "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RandomOneTestCaseNullCheck1()
        {
            String[] array = null;
            new Random().RandomOne( array );
        }

        [TestCase]
        public void RandomOneTestCase1()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings();

            var actual = random.RandomOne<string>( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RandomOneTestCase1NullCheck()
        {
            RandomEx.RandomOne( null, "", "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RandomOneTestCase1NullCheck1()
        {
            List<String> list = null;
            new Random().RandomOne<string>( list );
        }
    }
}