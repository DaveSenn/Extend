#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int16ExTest
    {
        [Test]
        public void RangeToTestCase()
        {
            const Int16 start = 0;
            const Int16 end = 200;

            var expected = new List<Int16>();
            for ( var i = start; i <= end; i++ )
                expected.Add( i );

            var actual = start.RangeTo( end );
            Assert.AreEqual( actual.First(), 0 );
            Assert.AreEqual( actual.Last(), 200 );
            Assert.AreEqual( expected.Count, actual.Count );

            for ( var i = 0; i < expected.Count; i++ )
                Assert.AreEqual( expected[i], actual[i] );
        }

        [Test]
        [ExpectedException( typeof (ArgumentException) )]
        public void RangeToTestCaseArgumentException()
        {
            const Int16 start = 100;

            start.RangeTo( 50 );
        }
    }
}