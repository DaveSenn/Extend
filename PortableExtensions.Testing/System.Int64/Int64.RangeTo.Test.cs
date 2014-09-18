#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class Int64ExTest
    {
        [Test]
        public void RangeToTestCase()
        {
            Int64 start = 0;
            Int64 end = 200;

            var expected = new List<Int64>();
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