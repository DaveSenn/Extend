#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Fact]
        public void ContainsAnyKeyTest()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.True( dictionary.ContainsAnyKey( dictionary.First()
                                                              .Key,
                                                    dictionary.Last()
                                                              .Key ) );
            Assert.True( dictionary.ContainsAnyKey( dictionary.First()
                                                              .Key ) );
            Assert.True( dictionary.ContainsAnyKey( dictionary.First()
                                                              .Key,
                                                    "test" ) );
            Assert.False( dictionary.ContainsAnyKey( "test" ) );
        }

        [Fact]
        public void ContainsAnyKeyTest1()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var keys = dictionary.GetAllKeysAsList();
            Assert.True( dictionary.ContainsAnyKey( keys ) );

            keys.RemoveAt( 0 );
            keys.Add( "test" );
            Assert.True( dictionary.ContainsAnyKey( keys ) );

            Assert.False( dictionary.ContainsAnyKey( new List<String> { "test", "test2" } ) );
        }

        [Fact]
        public void ContainsAnyKeyTest1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAnyKey( new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyKeyTest1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( keys );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyKeyTestNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAnyKey( new Object(), new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ContainsAnyKeyTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAnyKey( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}