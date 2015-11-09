﻿#region Usings

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
        public void GetAllKeysAsListCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.GetAllKeysAsList();

            test.ShouldThrow<ArgumentNullException>();
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