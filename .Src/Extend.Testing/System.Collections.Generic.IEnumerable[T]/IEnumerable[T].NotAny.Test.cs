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
        public void NotAnyTestCase()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny() );
        }

        [Test]
        public void NotAnyTestCase1()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );
        }

        [Test]
        public void NotAnyTestCase1NullCheck()
        {
            List<Object> list = null;
            Action test = () => list.NotAny( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotAnyTestCase1NullCheck1()
        {
            Func<Object, Boolean> func = null;
            Action test = () => new List<Object>().NotAny( func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void NotAnyTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.NotAny();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}