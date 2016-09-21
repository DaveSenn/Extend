#region Usings

using System;
using System.Collections.Generic;
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
        public void AddRangeTest()
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

            var actual = dictionary.AddRange( otherDictionary );
            actual
                .Should()
                .BeSameAs( dictionary );
            Assert.AreEqual( 4, dictionary.Count );
            Assert.IsTrue( dictionary.ContainsAll( otherDictionary ) );
        }

        [Test]
        public void AddRangeTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IDictionaryEx.AddRange( null, new Dictionary<Object, Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new Dictionary<Object, Object>().AddRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}