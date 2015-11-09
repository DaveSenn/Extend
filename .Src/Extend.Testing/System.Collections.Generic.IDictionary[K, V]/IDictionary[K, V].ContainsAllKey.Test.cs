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
        public void ContainsAllKeyTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.IsTrue( dictionary.ContainsAllKey( dictionary.First()
                                                                .Key,
                                                      dictionary.Last()
                                                                .Key ) );
            Assert.IsFalse( dictionary.ContainsAllKey( dictionary.First()
                                                                 .Key,
                                                       dictionary.Last()
                                                                 .Key,
                                                       "test" ) );
        }

        [Test]
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

        [Test]
        public void ContainsAllKeyTestCase1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.ContainsAllKey( new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllKeyTestCase1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            Action test = () => new Dictionary<Object, Object>().ContainsAllKey( keys );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllKeyTestCaseNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            Action test = () => dictionary.ContainsAllKey( new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllKeyTestCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().ContainsAllKey( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}