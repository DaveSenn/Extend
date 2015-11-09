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
    public partial class IDictionaryExTest
    {
        [Test]
        public void GetAllKeysTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var allKeys = dictionary.GetAllKeys()
                                    .ToList();
            Assert.IsTrue( dictionary.All( x => allKeys.Contains( x.Key ) ) );
        }

        [Test]
        public void GetAllKeysTestCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.GetAllKeys();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}