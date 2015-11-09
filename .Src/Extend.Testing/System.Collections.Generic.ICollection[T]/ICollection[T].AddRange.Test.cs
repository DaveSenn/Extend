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
        public void AddRangeTestCase()
        {
            var c = new List<String>();

            var result = c.AddRange( "test0", "test1", "test2" );
            Assert.AreEqual( 3, c.Count );
            Assert.AreSame( c, result );
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
        public void AddRangeTestCase1NullCheck()
        {
            Action test = () => CollectionTEx.AddRange( null, new List<String> { "test0", "test1", "test2" } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeTestCase1NullCheck1()
        {
            List<String> array = null;
            Action test = () => CollectionTEx.AddRange( new List<String>(), array );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeTestCaseNullCheck()
        {
            Action test = () => CollectionTEx.AddRange( null, "test0", "test1", "test2" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AddRangeTestCaseNullCheck1()
        {
            Action test = () => CollectionTEx.AddRange( new List<String>(), null );

            test.ShouldThrow<ArgumentException>();
        }
    }
}