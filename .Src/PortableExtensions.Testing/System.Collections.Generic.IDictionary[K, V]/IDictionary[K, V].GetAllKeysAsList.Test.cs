#region Usings

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
        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetAllKeysAsListCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            dictionary.GetAllKeysAsList();
        }

        [Test]
        public void GetAllKeysAsListTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var allKeys = dictionary.GetAllKeysAsList();
            Assert.IsTrue( dictionary.All( x => allKeys.Contains( x.Key ) ) );
        }
    }
}