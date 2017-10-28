#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IDictionaryExTest
    {
        [Fact]
        public void GetOrAddCase1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => IDictionaryEx.GetOrAdd( null, new KeyValuePair<Object, Object>( new Object(), new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase1NullCheck1()
        {
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new KeyValuePair<Object, Object>( null, new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase2NullCheck2()
        {
            Func<Object> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase3NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCase3NullCheck2()
        {
            Func<Object, Object> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCaseNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddCaseNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once MustUseReturnValue
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOrAddTest()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );

            actual = dictionary.GetOrAdd( key, value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );
        }

        [Fact]
        public void GetOrAddTest1()
        {
            var dictionary = new Dictionary<String, String>();
            var keyValuePair = new KeyValuePair<String, String>( RandomValueEx.GetRandomString(),
                                                                 RandomValueEx.GetRandomString() );

            var actual = dictionary.GetOrAdd( keyValuePair );
            Assert.Equal( keyValuePair.Value, actual );
            Assert.Contains( keyValuePair, dictionary );
            Assert.Single( dictionary );

            actual = dictionary.GetOrAdd( keyValuePair );
            Assert.Equal( keyValuePair.Value, actual );
            Assert.Contains( keyValuePair, dictionary );
            Assert.Single( dictionary );
        }

        [Fact]
        public void GetOrAddTest2()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, () => value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );

            actual = dictionary.GetOrAdd( key, () => value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );
        }

        [Fact]
        public void GetOrAddTest3()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, x => value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );

            actual = dictionary.GetOrAdd( key, x => value );
            Assert.Equal( value, actual );
            Assert.Contains( new KeyValuePair<String, String>( key, value ), dictionary );
            Assert.Single( dictionary );
        }
    }
}