using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingHelper;

namespace PortableExtensions.Tetst
{
    [TestFixture]
    public class EnumerableExTest
    {
        [Test]
        public void ForEachTest()
        {
            var list = RandomEx.GetRandomStrings ( RandomEx.GetRandomInt ( 5, 50 ) );
            var expected = list.Aggregate ( String.Empty, ( x, y ) => x += y );

            var actual = String.Empty;
            EnumerableEx.ForEach ( list, x => actual += x );

            Assert.AreEqual ( expected, actual );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void ForEachTestNullCheck()
        {
            List<String> list = null;
            EnumerableEx.ForEach ( list, x => { } );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void ForEachTestNullCheck1()
        {
            EnumerableEx.ForEach ( new List<String> { RandomEx.GetRandomString (), RandomEx.GetRandomString () }, null );
        }

        [Test]
        [ExpectedException ( typeof ( ArgumentNullException ) )]
        public void ForEachTestNullCheck2()
        {
            List<String> list = null;
            EnumerableEx.ForEach ( list, null );
        }
    }
}