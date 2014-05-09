#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void DistinctTestCase()
        {
            var list = new List<KeyValuePair<String, String>>
            {
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test1" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test1" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test2" ),
                new KeyValuePair<String, String>( RandomValueEx.GetRandomString(), "Test2" ),
            };

            var actual = list.Distinct( x => x.Value ).ToList();
            Assert.AreEqual( 3, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test" ) );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test1" ) );
            Assert.AreEqual( 1, actual.Count( x => x.Value == "Test2" ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void DistinctTestCaseNullCheck()
        {
            List<KeyValuePair<Object, Object>> list = null;
            list.Distinct( x => x.Value );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void DistinctTestCaseNullCheck1()
        {
            Func<Object, Boolean> func = null;
            new List<Object>().Distinct( func );
        }
    }
}