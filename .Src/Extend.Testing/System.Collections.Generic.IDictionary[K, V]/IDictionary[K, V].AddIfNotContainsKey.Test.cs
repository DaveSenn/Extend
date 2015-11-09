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
        public void AddIfNotContainsKey1TestCaseNullCheck()
        {
            var keyValuePair = new KeyValuePair<Object, Object>();
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( keyValuePair );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKey1TestCaseNullCheck1()
        {
            Action test = () => IDictionaryEx.AddIfNotContainsKey( null, new KeyValuePair<Object, Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var result = dic.AddIfNotContainsKey( key, RandomValueEx.GetRandomString() );
            Assert.IsTrue( result );
            Assert.AreEqual( 1, dic.Count );

            result = dic.AddIfNotContainsKey( key, RandomValueEx.GetRandomString() );
            Assert.IsFalse( false );
            Assert.AreEqual( 1, dic.Count );
        }

        [Test]
        public void AddIfNotContainsKeyTestCase1()
        {
            var dic = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var keyValuePair = new KeyValuePair<String, String>( key, RandomValueEx.GetRandomString() );

            var result = dic.AddIfNotContainsKey( keyValuePair );
            Assert.IsTrue( result );
            Assert.AreEqual( 1, dic.Count );

            result = dic.AddIfNotContainsKey( keyValuePair );
            Assert.IsFalse( result );
            Assert.AreEqual( 1, dic.Count );
        }

        [Test]
        public void AddIfNotContainsKeyTestCase2()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var result = dic.AddIfNotContainsKey( key, () => RandomValueEx.GetRandomString() );
            Assert.IsTrue( result );
            Assert.AreEqual( 1, dic.Count );

            result = dic.AddIfNotContainsKey( key, () => RandomValueEx.GetRandomString() );
            Assert.IsFalse( false );
            Assert.AreEqual( 1, dic.Count );
        }

        [Test]
        public void AddIfNotContainsKeyTestCase2NullCheck()
        {
            Action test = () => IDictionaryEx.AddIfNotContainsKey( null, new Object(), () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase2NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( null, () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase2NullCheck2()
        {
            Func<Object> func = null;
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase3()
        {
            var key = RandomValueEx.GetRandomString();
            var dic = new Dictionary<String, String>();

            var result = dic.AddIfNotContainsKey( key, x => RandomValueEx.GetRandomString() );
            Assert.IsTrue( result );
            Assert.AreEqual( 1, dic.Count );

            result = dic.AddIfNotContainsKey( key, x => RandomValueEx.GetRandomString() );
            Assert.IsFalse( false );
            Assert.AreEqual( 1, dic.Count );
        }

        [Test]
        public void AddIfNotContainsKeyTestCase3NullCheck()
        {
            Action test = () => IDictionaryEx.AddIfNotContainsKey( null, new Object(), x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase3NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( null, x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCase3NullCheck2()
        {
            Func<Object, Object> func = null;
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCaseNullCheck()
        {
            Action test = () => IDictionaryEx.AddIfNotContainsKey( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddIfNotContainsKeyTestCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().AddIfNotContainsKey( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}