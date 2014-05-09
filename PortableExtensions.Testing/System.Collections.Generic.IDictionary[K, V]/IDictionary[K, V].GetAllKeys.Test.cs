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
        public void GetAllKeysTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var allKeys = dictionary.GetAllKeys().ToList();
            Assert.IsTrue( dictionary.All( x => allKeys.Contains( x.Key ) ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetAllKeysTestCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            dictionary.GetAllKeys();
        }
    }
}