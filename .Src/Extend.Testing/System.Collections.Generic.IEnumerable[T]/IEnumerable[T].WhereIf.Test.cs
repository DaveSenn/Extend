#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void WhereIfTest()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, x => true );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( true, x => false );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( false, x => true );
            Assert.AreEqual( 0, actual.Count() );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, x => true );
            Assert.AreEqual( list.Count, actual.Count() );

            actual = list.WhereIf( true, x => false );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( false, x => true );
            Assert.AreSame( list, actual );
        }

        [Test]
        public void WhereIfTest1()
        {
            var list = new List<String>();

            var actual = list.WhereIf( true, ( x, i ) => true );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.AreEqual( 0, actual.Count() );

            list = RandomValueEx.GetRandomStrings();

            actual = list.WhereIf( true, ( x, i ) => true );
            Assert.AreEqual( list.Count, actual.Count() );

            actual = list.WhereIf( true, ( x, i ) => false );
            Assert.AreEqual( 0, actual.Count() );

            actual = list.WhereIf( false, ( x, i ) => true );
            Assert.AreSame( list, actual );
        }

        [Test]
        public void WhereIfTest1NullCheck()
        {
            List<Object> list = null;
            Action test = () => list.WhereIf( true, ( x, i ) => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhereIfTest1NullCheck1()
        {
            Func<Object, Int32, Boolean> func = null;
            Action test = () => new List<Object>().WhereIf( true, func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhereIfTestNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.WhereIf( true, x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhereIfTestNullCheck1()
        {
            Func<Object, Boolean> func = null;
            Action test = () => new List<Object>().WhereIf( true, func );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}