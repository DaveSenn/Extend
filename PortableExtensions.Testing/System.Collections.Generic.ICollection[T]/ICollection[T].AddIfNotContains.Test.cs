#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [TestCase]
        public void AddIfNotContainsTestCase()
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

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddIfNotContainsTestCaseNullCheck()
        {
            CollectionTEx.AddIfNotContains( null, RandomValueEx.GetRandomString() );
        }
    }
}