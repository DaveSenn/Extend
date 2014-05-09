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
        public void ContainsAllKeyTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.IsTrue( dictionary.ContainsAllKey( dictionary.First().Key, dictionary.Last().Key ) );
            Assert.IsFalse( dictionary.ContainsAllKey( dictionary.First().Key, dictionary.Last().Key, "test" ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllKeyTestCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            dictionary.ContainsAllKey( new Object(), new Object(), new Object() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllKeyTestCaseNullCheck1()
        {
            new Dictionary<Object, Object>().ContainsAllKey( null );
        }

        [TestCase]
        public void ContainsAllKeyTestCase1()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var allKeys = dictionary.GetAllKeysAsList();
            Assert.IsTrue( dictionary.ContainsAllKey( allKeys ) );

            allKeys.Add( "test" );
            Assert.IsFalse( dictionary.ContainsAllKey( allKeys ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllKeyTestCase1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            dictionary.ContainsAllKey( new List<Object>() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllKeyTestCase1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            new Dictionary<Object, Object>().ContainsAllKey( keys );
        }
    }
}