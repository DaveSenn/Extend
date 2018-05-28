#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Fact]
        public void ContainsAllKeyTest()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.True( dictionary.ContainsAllKey( dictionary.First()
                                                              .Key,
                                                    dictionary.Last()
                                                              .Key ) );
            Assert.False( dictionary.ContainsAllKey( dictionary.First()
                                                               .Key,
                                                     dictionary.Last()
                                                               .Key,
                                                     "test" ) );
        }

        [Fact]
        public void ContainsAllKeyTest1()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var allKeys = dictionary.GetAllKeysAsList();
            Assert.True( dictionary.ContainsAllKey( allKeys ) );

            allKeys.Add( "test" );
            Assert.False( dictionary.ContainsAllKey( allKeys ) );
        }

        [Fact]
        public void ContainsAllKeyTest1NullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAllKey( new List<Object>() );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ContainsAllKeyTest1NullCheck1()
        {
            IEnumerable<Object> keys = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAllKey( keys );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ContainsAllKeyTestNullCheck()
        {
            Dictionary<Object, Object> dictionary = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => dictionary.ContainsAllKey( new Object(), new Object(), new Object() );

            Assert.Throws<ArgumentNullException>( test );
        }

        [Fact]
        public void ContainsAllKeyTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Dictionary<Object, Object>().ContainsAllKey( null );

            Assert.Throws<ArgumentNullException>( test );
        }
    }
}