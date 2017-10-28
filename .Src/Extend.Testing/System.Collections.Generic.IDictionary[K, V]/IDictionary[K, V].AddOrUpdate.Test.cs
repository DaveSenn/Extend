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
        public void AddOrUpdateTest()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            var result = dic.AddOrUpdate( key, valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );
        }

        [Fact]
        public void AddOrUpdateTest1()
        {
            var key = RandomValueEx.GetRandomString();
            var pair = new KeyValuePair<String, String>( key, RandomValueEx.GetRandomString() );
            var dic = new Dictionary<String, String>();

            var result = dic.AddOrUpdate( pair );
            Assert.Single( dic );
            Assert.Equal( pair.Value, result );

            pair = new KeyValuePair<String, String>( key, RandomValueEx.GetRandomString() );
            result = dic.AddOrUpdate( pair );
            Assert.Single( dic );
            Assert.Equal( pair.Value, result );
        }

        [Fact]
        public void AddOrUpdateTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IDictionaryEx.AddOrUpdate( null, new KeyValuePair<Object, Object>( new Object(), new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest1NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( new KeyValuePair<Object, Object>( null, new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest2()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            // ReSharper disable once AccessToModifiedClosure
            var result = dic.AddOrUpdate( key, () => valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, () => valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );
        }

        [Fact]
        public void AddOrUpdateTest2NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest2NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest2NullCheck2()
        {
            Func<String> func = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest3()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            // ReSharper disable once AccessToModifiedClosure
            var result = dic.AddOrUpdate( key, x => valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, x => valueToAdd );
            Assert.Single( dic );
            Assert.Equal( valueToAdd, result );
        }

        [Fact]
        public void AddOrUpdateTest3NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTest3NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AddOrUpdateTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}