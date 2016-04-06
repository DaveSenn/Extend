#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void StringJoinTest()
        {
            var list = new List<String>();
            var actual = list.StringJoin( "," );
            Assert.AreEqual( String.Empty, actual );

            actual = list.StringJoin();
            Assert.AreEqual( String.Empty, actual );

            list = RandomValueEx.GetRandomStrings();
            actual = list.StringJoin( "," );
            var expected = String.Join( ",", list );
            Assert.AreEqual( expected, actual );

            actual = list.StringJoin();
            expected = String.Join( "", list );
            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void StringJoinTestNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.StringJoin( "" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}