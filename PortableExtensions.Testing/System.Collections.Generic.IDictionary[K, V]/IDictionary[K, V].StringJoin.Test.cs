#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [TestCase]
        public void StringJoinTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var actual = dictionary.StringJoin();
            var expected = "{0}={1}{2}={3}".F( dictionary.First().Key, dictionary.First().Value, dictionary.Last().Key,
                                               dictionary.Last().Value );
            Assert.AreEqual( expected, actual );

            actual = dictionary.StringJoin( ",", ";" );
            expected = "{0},{1};{2},{3}".F( dictionary.First().Key, dictionary.First().Value, dictionary.Last().Key,
                                            dictionary.Last().Value );
            Assert.AreEqual( expected, actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void StringJoinTestCaseNullCheck()
        {
            Dictionary<String, String> dictionary = null;
            dictionary.StringJoin( "", "" );
        }
    }
}