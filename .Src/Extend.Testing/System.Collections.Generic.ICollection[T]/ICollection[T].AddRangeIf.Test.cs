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
        public void AddRangeIfTestCase()
        {
            var c = new List<String>();

            var result = c.AddRangeIf( x => true, "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIf( x => false, "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfTestCase1()
        {
            var c = new List<String>();

            var result = c.AddRangeIf( x => true, new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIf( x => false, new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfTestCase1NullCheck()
        {
            Action test = () => CollectionTEx.AddRangeIf( null, x => true, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestCase1NullCheck1()
        {
            Action test = () => new List<String>().AddRangeIf( x => true, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestCase1NullCheck2()
        {
            Action test = () => new List<String>().AddRangeIf( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestCaseNullCheck()
        {
            Action test = () => CollectionTEx.AddRangeIf( null, x => true, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestCaseNullCheck1()
        {
            Action test = () => new List<String>().AddRangeIf( x => true, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestCaseNullCheck2()
        {
            Action test = () => new List<String>().AddRangeIf( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}