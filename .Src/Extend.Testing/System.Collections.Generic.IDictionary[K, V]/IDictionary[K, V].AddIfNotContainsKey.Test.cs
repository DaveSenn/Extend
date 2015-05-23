#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IDictionaryExTest
    {
        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKey1TestCaseNullCheck()
        {
            var keyValuePair = new KeyValuePair<Object, Object>();
            new Dictionary<Object, Object>().AddIfNotContainsKey( keyValuePair );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKey1TestCaseNullCheck1()
        {
            IDictionaryEx.AddIfNotContainsKey( null, new KeyValuePair<Object, Object>() );
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase2NullCheck()
        {
            IDictionaryEx.AddIfNotContainsKey( null, new Object(), () => new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase2NullCheck1()
        {
            new Dictionary<Object, Object>().AddIfNotContainsKey( null, () => new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase2NullCheck2()
        {
            Func<Object> func = null;
            new Dictionary<Object, Object>().AddIfNotContainsKey( new Object(), func );
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase3NullCheck()
        {
            IDictionaryEx.AddIfNotContainsKey( null, new Object(), x => new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase3NullCheck1()
        {
            new Dictionary<Object, Object>().AddIfNotContainsKey( null, x => new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCase3NullCheck2()
        {
            Func<Object, Object> func = null;
            new Dictionary<Object, Object>().AddIfNotContainsKey( new Object(), func );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCaseNullCheck()
        {
            IDictionaryEx.AddIfNotContainsKey( null, new Object(), new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AddIfNotContainsKeyTestCaseNullCheck1()
        {
            new Dictionary<Object, Object>().AddIfNotContainsKey( null, new Object() );
        }
    }
}