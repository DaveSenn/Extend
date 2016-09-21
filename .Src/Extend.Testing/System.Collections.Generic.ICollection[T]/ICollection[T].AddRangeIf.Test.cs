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
        public void AddRangeIfTest()
        {
            var c = new List<String>();

            var result = c.AddRangeIf( x => true, "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIf( x => false, "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfTest1()
        {
            var c = new List<String>();

            var result = c.AddRangeIf( x => true, new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );

            c.AddRangeIf( x => false, new List<String> { "test0", "test1", "test2" } );
            Assert.AreEqual( 3, c.Count );
        }

        [Test]
        public void AddRangeIfTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRangeIf( null, x => true, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTest1NullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIf( x => true, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTest1NullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIf( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddRangeIf( null, x => true, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIf( x => true, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeIfTestNullCheck2()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().AddRangeIf( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}