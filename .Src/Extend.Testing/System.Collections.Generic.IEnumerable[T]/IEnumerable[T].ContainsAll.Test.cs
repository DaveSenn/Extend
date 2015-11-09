#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ContainsAllTestCase()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( "test" ) );
            Assert.IsTrue( list.ContainsAll( "test", "test1" ) );
            Assert.IsFalse( list.ContainsAll( "test", "test1", "test2" ) );
        }

        [Test]
        public void ContainsAllTestCase1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAll( list ) );
            Assert.IsFalse( list.ContainsAll( new List<String> { "test", "test1", "test2" } ) );
        }

        [Test]
        public void ContainsAllTestCase1NullCheck()
        {
            Action test = () => IEnumerableTEx.ContainsAll( null, new List<String>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCase1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            Action test = () => new List<Object>().ContainsAll( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCaseNullCheck()
        {
            Action test = () => IEnumerableTEx.ContainsAll( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCaseNullCheck1()
        {
            Object[] array = null;
            Action test = () => new List<Object>().ContainsAll( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}