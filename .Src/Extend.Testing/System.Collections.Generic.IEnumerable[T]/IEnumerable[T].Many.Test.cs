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
        public void ManyTestCase()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.Many() );
        }

        [Test]
        public void ManyTestCase1()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsFalse( list.Many( x => false ) );
            Assert.IsTrue( list.Many( x => true ) );
        }

        [Test]
        public void ManyTestCase1NullCheck()
        {
            List<Object> list = null;
            Action test = () => list.Many( x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ManyTestCase1NullCheck1()
        {
            Action test = () => new List<Object>().Many( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ManyTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.Many();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}