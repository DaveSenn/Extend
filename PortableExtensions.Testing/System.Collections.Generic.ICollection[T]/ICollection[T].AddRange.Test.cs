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
        [Test]
        public void AddRangeTestCase()
        {
            var c = new List<String>();

            var result = c.AddRange( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCaseNullCheck()
        {
            CollectionTEx.AddRange( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCaseNullCheck1()
        {
            CollectionTEx.AddRange( new List<String>(), null );
        }

        [Test]
        public void AddRangeTestCase1()
        {
            var c = new List<String>();

            var result = CollectionTEx.AddRange( c, new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCase1NullCheck()
        {
            CollectionTEx.AddRange( null, new List<String> { "test0", "test1", "test2" } );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AddRangeTestCase1NullCheck1()
        {
            List<String> array = null;
            CollectionTEx.AddRange( new List<String>(), array );
        }
    }
}