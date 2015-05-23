#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ToDictionaryTestCase()
        {
            var list = new List<Tuple<Int32, String>>
            {
                new Tuple<Int32, String>( 1, "test1.1" ),
                new Tuple<Int32, String>( 1, "test1.2" ),
                new Tuple<Int32, String>( 1, "test1.3" ),
                new Tuple<Int32, String>( 2, "test2.1" ),
                new Tuple<Int32, String>( 2, "test2.2" ),
                new Tuple<Int32, String>( 2, "test2.3" ),
                new Tuple<Int32, String>( 3, "test3.1" ),
                new Tuple<Int32, String>( 3, "test3.2" ),
                new Tuple<Int32, String>( 3, "test3.3" ),
            };

            var groups = list.GroupBy( x => x.Item1 );
            var actual = groups.ToDictionary();

            Assert.AreEqual( 3, actual.Count );

            Assert.AreEqual( 3, actual[1].Count );
            Assert.AreEqual( 3, actual[2].Count );
            Assert.AreEqual( 3, actual[3].Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ToDictionaryTestCaseNullCheck()
        {
            IEnumerable<IGrouping<Object, Object>> groupings = null;
            groupings.ToDictionary();
        }
    }
}