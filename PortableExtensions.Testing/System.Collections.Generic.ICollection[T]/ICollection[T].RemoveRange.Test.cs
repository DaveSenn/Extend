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
        public void RemoveRangeTestCase()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.AreEqual( values.Count, list.Count );

            var result = list.RemoveRange( values.ToArray() );
            Assert.AreEqual( 0, list.Count );
            Assert.AreSame( list, result );
        }

        [Test]
        public void RemoveRangeTestCase1()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.AreEqual( values.Count, list.Count );

            var result = list.RemoveRange( values );
            Assert.AreEqual( 0, list.Count );
            Assert.AreSame( list, result );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeTestCase1NullCheck()
        {
            CollectionTEx.RemoveRange( null, new List<String> { "test0", "test1", "test2" } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeTestCase1NullCheck1()
        {
            new List<String>().RemoveRange( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeTestCaseNullCheck()
        {
            CollectionTEx.RemoveRange( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeTestCaseNullCheck1()
        {
            new List<String>().RemoveRange( null );
        }
    }
}