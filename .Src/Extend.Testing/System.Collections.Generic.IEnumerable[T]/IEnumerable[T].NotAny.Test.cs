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
        public void NotAnyTest()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny() );
        }

        [Test]
        public void NotAnyTest1()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );
        }

        [Test]
        public void NotAnyTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.NotAny( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotAnyTest1NullCheck1()
        {
            Func<Object, Boolean> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().NotAny( func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotAnyTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.NotAny();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}