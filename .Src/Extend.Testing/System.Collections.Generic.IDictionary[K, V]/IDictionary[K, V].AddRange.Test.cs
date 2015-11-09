﻿#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        public void AddRangeTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var otherDictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.AreEqual( 2, dictionary.Count );

            dictionary.AddRange( otherDictionary );
            Assert.AreEqual( 4, dictionary.Count );
            Assert.IsTrue( dictionary.ContainsAll( otherDictionary ) );
        }

        [Test]
        public void AddRangeTestCaseNullCheck()
        {
            Action test = () => IDictionaryEx.AddRange( null, new Dictionary<Object, Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeTestCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}