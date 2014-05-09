#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [TestCase]
        public void RangeToTestCase()
        {
            var start = 0;
            var end = 200;

            var expected = new List<Int32>();
            for ( var i = start; i <= end; i++ )
                expected.Add( i );

            var actual = start.RangeTo( end );
            Assert.AreEqual( actual.First(), 0 );
            Assert.AreEqual( actual.Last(), 200 );
            Assert.AreEqual( expected.Count, actual.Count );

            for ( var i = 0; i < expected.Count; i++ )
                Assert.AreEqual( expected[i], actual[i] );
        }
    }
}