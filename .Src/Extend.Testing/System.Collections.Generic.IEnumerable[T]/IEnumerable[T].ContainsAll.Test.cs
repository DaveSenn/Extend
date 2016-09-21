#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ContainsAllTest()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( "test" ) );
            Assert.IsTrue( list.ContainsAll( "test", "test1" ) );
            Assert.IsFalse( list.ContainsAll( "test", "test1", "test2" ) );
        }

        [Test]
        public void ContainsAllTest1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAll( list ) );
            Assert.IsFalse( list.ContainsAll( new List<String> { "test", "test1", "test2" } ) );
        }

        [Test]
        public void ContainsAllTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IEnumerableTEx.ContainsAll( null, new List<String>() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTest1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ContainsAll( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestNullCheck()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => IEnumerableTEx.ContainsAll( null, new Object(), new Object() );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestNullCheck1()
        {
            Object[] array = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ContainsAll( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}