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
        public void GetOrAddCase1NullCheck()
        {
            Action test = () => IDictionaryEx.GetOrAdd( null, new KeyValuePair<Object, Object>( new Object(), new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase1NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new KeyValuePair<Object, Object>( null, new Object() ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase2NullCheck()
        {
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase2NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, () => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase2NullCheck2()
        {
            Func<Object> func = null;
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase3NullCheck()
        {
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase3NullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, x => new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCase3NullCheck2()
        {
            Func<Object, Object> func = null;
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( new Object(), func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCaseNullCheck()
        {
            Action test = () => IDictionaryEx.GetOrAdd( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddCaseNullCheck1()
        {
            Action test = () => new Dictionary<Object, Object>().GetOrAdd( null, new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetOrAddTestCase()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase1()
        {
            var dictionary = new Dictionary<String, String>();
            var keyValuePair = new KeyValuePair<String, String>( RandomValueEx.GetRandomString(),
                                                                 RandomValueEx.GetRandomString() );

            var actual = dictionary.GetOrAdd( keyValuePair );
            Assert.AreEqual( keyValuePair.Value, actual );
            Assert.IsTrue( dictionary.Contains( keyValuePair ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( keyValuePair );
            Assert.AreEqual( keyValuePair.Value, actual );
            Assert.IsTrue( dictionary.Contains( keyValuePair ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase2()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, () => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, () => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }

        [Test]
        public void GetOrAddTestCase3()
        {
            var dictionary = new Dictionary<String, String>();
            var key = RandomValueEx.GetRandomString();
            var value = RandomValueEx.GetRandomString();

            var actual = dictionary.GetOrAdd( key, x => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );

            actual = dictionary.GetOrAdd( key, x => value );
            Assert.AreEqual( value, actual );
            Assert.IsTrue( dictionary.Contains( new KeyValuePair<String, String>( key, value ) ) );
            Assert.AreEqual( 1, dictionary.Count );
        }
    }
}