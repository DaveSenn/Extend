#region Usings

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
        public void AddOrUpdateTestCase()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            var result = dic.AddOrUpdate( key, valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );
        }

        [Test]
        public void AddOrUpdateTestCase1()
        {
            var key = RandomValueEx.GetRandomString();
            var pair = new KeyValuePair<String, String>( key, RandomValueEx.GetRandomString() );
            var dic = new Dictionary<String, String>();

            var result = dic.AddOrUpdate( pair );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( pair.Value, result );

            pair = new KeyValuePair<String, String>( key, RandomValueEx.GetRandomString() );
            result = dic.AddOrUpdate( pair );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( pair.Value, result );
        }

        [Test]
        public void AddOrUpdateTestCase1NullCheck()
        {
            Action test = () => IDictionaryEx.AddOrUpdate( null, new KeyValuePair<Object, Object>( new Object(), new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase1NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( new KeyValuePair<Object, Object>( null, new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase2()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            var result = dic.AddOrUpdate( key, () => valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, () => valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );
        }

        [Test]
        public void AddOrUpdateTestCase2NullCheck()
        {
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase2NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase2NullCheck2()
        {
            Func<String> func = null;
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase3()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var valueToAdd = RandomValueEx.GetRandomString();
            var result = dic.AddOrUpdate( key, x => valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );

            valueToAdd = RandomValueEx.GetRandomString();
            result = dic.AddOrUpdate( key, x => valueToAdd );
            Assert.AreEqual( 1, dic.Count );
            Assert.AreEqual( valueToAdd, result );
        }

        [Test]
        public void AddOrUpdateTestCase3NullCheck()
        {
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCase3NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCaseNullCheck()
        {
            Action test = () => IDictionaryEx.AddOrUpdate( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddOrUpdateTestCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddOrUpdate( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}