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
        public void GetAllKeysTest()
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
        public void GetAllKeysTestNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.GetAllKeys();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}