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
        public void RemoveRangeTest()
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
        public void RemoveRangeTest1()
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
        public void RemoveRangeTest1NullCheck()
        {
            Action test = () => CollectionTEx.RemoveRange( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RemoveRangeTest1NullCheck1()
        {
            Action test = () => new List<String>().RemoveRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RemoveRangeTestNullCheck()
        {
            Action test = () => CollectionTEx.RemoveRange( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RemoveRangeTestNullCheck1()
        {
            Action test = () => new List<String>().RemoveRange( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}