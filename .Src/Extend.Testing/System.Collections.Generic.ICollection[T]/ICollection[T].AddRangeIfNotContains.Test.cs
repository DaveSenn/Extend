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
        public void AddRangeIfNotContains1TestCaseNullCheck()
        {
            Action test = () => CollectionTEx.AddRangeIfNotContains( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfNotContains1TestCaseNullCheck1()
        {
            List<String> list = null;
            Action test = () => new List<String>().AddRangeIfNotContains( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfNotContainsTestCase()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIfNotContains( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfNotContainsTestCase1()
        {
            var c = new List<String>();

            var result = c.AddRangeIfNotContains( new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIfNotContains( new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfNotContainsTestCaseNullCheck()
        {
            Action test = () => CollectionTEx.AddRangeIfNotContains( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfNotContainsTestCaseNullCheck1()
        {
            Action test = () => new List<String>().AddRangeIfNotContains( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}