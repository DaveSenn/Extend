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
        public void ContainsAnyTestCase()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAny( "test" ) );
            Assert.IsTrue( list.ContainsAny( "test", "test1" ) );
            Assert.IsTrue( list.ContainsAny( "test", "test1", "test2" ) );
            Assert.IsFalse( list.ContainsAny( "asdasd" ) );
        }

        [Test]
        public void ContainsAnyTestCase1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAny( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAny( new List<String> { "test", "test1" } ) );
            Assert.IsTrue( list.ContainsAny( new List<String> { "test", "test1", "test2" } ) );
            Assert.IsFalse( list.ContainsAny( new List<String> { "asdasd" } ) );
        }

        [Test]
        public void ContainsAnyTestCase1NullCheck()
        {
            Action test = () => IEnumerableTEx.ContainsAny( null, new List<Object>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCase1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            Action test = () => new List<String>().ContainsAny( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCaseNullCheck()
        {
            Action test = () => IEnumerableTEx.ContainsAny( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCaseNullCheck1()
        {
            Object[] array = null;
            Action test = () => new List<String>().ContainsAny( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}