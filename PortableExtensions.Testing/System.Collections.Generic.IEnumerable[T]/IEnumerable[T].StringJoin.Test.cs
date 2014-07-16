#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void StringJoinTestCase()
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void StringJoinTestCaseNullCheck()
        {
            List<Object> list = null;
            list.StringJoin( "" );
        }
    }
}