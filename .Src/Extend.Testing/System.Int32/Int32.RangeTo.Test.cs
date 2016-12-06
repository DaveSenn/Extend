#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class Int32ExTest
    {
        [Test]
        public void RangeToTest()
        {
            const Int32 start = 0;
            const Int32 end = 200;

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

        [Test]
        public void RangeToTestArgumentException()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => 200.RangeTo( 100 );

            test.ShouldThrow<ArgumentException>();
        }
    }
}