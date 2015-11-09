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
        public void ContainsAnyKeyTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.IsTrue( dictionary.ContainsAnyKey( dictionary.First()
                                                                .Key,
                                                      dictionary.Last()
                                                                .Key ) );
            Assert.IsTrue( dictionary.ContainsAnyKey( dictionary.First()
                                                                .Key ) );
            Assert.IsTrue( dictionary.ContainsAnyKey( dictionary.First()
                                                                .Key,
                                                      "test" ) );
            Assert.IsFalse( dictionary.ContainsAnyKey( "test" ) );
        }

        [Test]
        public void ContainsAnyKeyTestCase1()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var keys = dictionary.GetAllKeysAsList();
            Assert.IsTrue( dictionary.ContainsAnyKey( keys ) );

            keys.RemoveAt( 0 );
            keys.Add( "test" );
            Assert.IsTrue( dictionary.ContainsAnyKey( keys ) );

            Assert.IsFalse( dictionary.ContainsAnyKey( new List<String> { "test", "test2" } ) );
        }

        [Test]
        public void ContainsAnyKeyTestCase1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.ContainsAnyKey( new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTestCase1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( keys );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTestCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.ContainsAnyKey( new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTestCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}