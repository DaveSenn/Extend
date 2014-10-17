#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddRangeIfNotContains1TestCaseNullCheck ()
        {
            CollectionTEx.AddRangeIfNotContains( null, new List<String> {"test0", "test1", "test2"} );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddRangeIfNotContains1TestCaseNullCheck1 ()
        {
            List<String> list = null;
            new List<String>().AddRangeIfNotContains( list );
        }

        [Test]
        public void AddRangeIfNotContainsTestCase ()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfNotContainsTestCase1 ()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( new List<String> {"test0", "test1", "test2"} );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIfNotContains( new List<String> {"test0", "test1", "test2"} );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddRangeIfNotContainsTestCaseNullCheck ()
        {
            CollectionTEx.AddRangeIfNotContains( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddRangeIfNotContainsTestCaseNullCheck1 ()
        {
            new List<String>().AddRangeIfNotContains( null );
        }
    }
}