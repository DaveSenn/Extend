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
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Test]
        public void ContainsAnyKeyTest()
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
        public void ContainsAnyKeyTest1()
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
        public void ContainsAnyKeyTest1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAnyKey( new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTest1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( keys );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTestNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAnyKey( new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyKeyTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}