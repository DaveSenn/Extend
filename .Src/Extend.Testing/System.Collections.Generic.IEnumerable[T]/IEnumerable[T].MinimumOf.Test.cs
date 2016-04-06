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
        public void MinimumOfTest()
        {
            var list = new List<String>();
            Assert.IsFalse( list.MinimumOf( 1, x => true ) );
            Assert.IsTrue( list.MinimumOf( 0, x => false ) );
            Assert.IsTrue( list.MinimumOf( 0, x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.MinimumOf( 9, x => true ) );
            Assert.IsTrue( list.MinimumOf( 10, x => true ) );
            Assert.IsFalse( list.MinimumOf( 10, x => false ) );
            Assert.IsFalse( list.MinimumOf( 11, x => true ) );
        }

        [Test]
        public void MinimumOfTest1()
        {
            var list = new List<String>();
            Assert.IsFalse( list.MinimumOf( 1 ) );
            Assert.IsTrue( list.MinimumOf( 0 ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.MinimumOf( 9 ) );
            Assert.IsTrue( list.MinimumOf( 10 ) );
            Assert.IsFalse( list.MinimumOf( 11 ) );
        }

        [Test]
        public void MinimumOfTest1NullCheck()
        {
            List<Object> list = null;
            Action test = () => list.MinimumOf( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumOfTestNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.MinimumOf( 10, x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void MinimumOfTestNullCheck1()
        {
            List<Object> list = null;
            Action test = () => list.MinimumOf( 10, null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}