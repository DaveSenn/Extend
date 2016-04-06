#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void AddIfNotContainsTest()
        {
            var c = new List<String>();

            var result = c.AddIfNotContains( RandomValueEx.GetRandomString() );
            Assert.AreEqual( 1, c.Count );
            Assert.IsTrue( result );

            var valueToAdd = RandomValueEx.GetRandomString();
            c.Add( valueToAdd );
            result = c.AddIfNotContains( valueToAdd );
            Assert.AreEqual( 2, c.Count );
            Assert.IsFalse( result );
        }

        [Test]
        public void AddIfNotContainsTestNullCheck()
        {
            Action test = () => CollectionTEx.AddIfNotContains( null, RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}