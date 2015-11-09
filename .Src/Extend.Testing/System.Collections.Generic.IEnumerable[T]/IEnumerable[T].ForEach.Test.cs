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
        public void ForEachTestCase()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            var actual = IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.AreSame( list, actual );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( otherList.Contains ) );
        }

        [Test]
        public void ForEachTestCase1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            Action test = () => IEnumerableTEx.ForEach( list, x => list.Remove( x ) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ForEachTestCase1NullCheck()
        {
            List<Object> list = null;
            Action test = () => list.ForEach( ( x, i ) => { } );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForEachTestCase1NullCheck1()
        {
            Action<Object, Int32> action = null;
            Action test = () => new List<Object>().ForEach( action );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForEachTestCase2()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            var actual = IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.AreSame( list, actual );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( otherList.Contains ) );
        }

        [Test]
        public void ForEachTestCase3()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            Action test = () => list.ForEach( ( x, i ) => list.Remove( x ) );

            test.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ForEachTestCase4()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var total = 0;
            var actual = list.ForEach( ( x, i ) => total += i );

            Assert.AreSame( list, actual );
            Assert.AreEqual( 45, total );
        }

        [Test]
        public void ForEachTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => IEnumerableTEx.ForEach( list, Console.WriteLine );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForEachTestCaseNullCheck1()
        {
            Action<Object> action = null;
            Action test = () => IEnumerableTEx.ForEach( new List<Object>(), action );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}