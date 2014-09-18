#region Using

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
        public void AddRangeTestCase()
        {
            var dictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            var otherDictionary = new Dictionary<String, String>
            {
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() },
                { RandomValueEx.GetRandomString(), RandomValueEx.GetRandomString() }
            };

            Assert.AreEqual( 2, dictionary.Count );

            dictionary.AddRange( otherDictionary );
            Assert.AreEqual( 4, dictionary.Count );
            Assert.IsTrue( dictionary.ContainsAll( otherDictionary ) );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCaseNullCheck()
        {
            IDictionaryEx.AddRange( null, new Dictionary<Object, Object>() );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCaseNullCheck1()
        {
            new Dictionary<Object, Object>().AddRange( null );
        }
    }
}