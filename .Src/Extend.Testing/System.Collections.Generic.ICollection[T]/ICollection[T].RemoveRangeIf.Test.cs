#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void RemoveRangeIfTestCase()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.AreEqual( values.Count, list.Count );

            var result = list.RemoveRangeIf( x => false, values.ToArray() );
            Assert.AreEqual( values.Count, list.Count );
            Assert.AreSame( list, result );

            list.RemoveRangeIf( x => true, values.ToArray() );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        public void RemoveRangeIfTestCase1()
        {
            var list = new List<String>();
            var values = RandomValueEx.GetRandomStrings( 10 );
            list.AddRange( values );
            Assert.AreEqual( values.Count, list.Count );

            var result = list.RemoveRangeIf( x => false, values );
            Assert.AreEqual( values.Count, list.Count );
            Assert.AreSame( list, result );

            list.RemoveRangeIf( x => true, values );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeIfTestCase1NullCheck1()
        {
            new List<String>().RemoveRangeIf( x => false, null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeIfTestCase1NullCheck2()
        {
            new List<String>().RemoveRangeIf( null, new List<String> { "test0", "test1", "test2" } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeIfTestCaseNullCheck()
        {
            CollectionTEx.RemoveRangeIf( null, x => false, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeIfTestCaseNullCheck1()
        {
            new List<String>().RemoveRangeIf( x => false, null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeIfTestCaseNullCheck2()
        {
            new List<String>().RemoveRangeIf( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveRangeTestIfCase1NullCheck()
        {
            CollectionTEx.RemoveRangeIf( null, x => false, new List<String> { "test0", "test1", "test2" } );
        }
    }
}