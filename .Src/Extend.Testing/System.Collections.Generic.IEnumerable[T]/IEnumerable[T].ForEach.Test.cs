#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
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
        [ExpectedException( typeof (InvalidOperationException) )]
        public void ForEachTestCase1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            var actual = IEnumerableTEx.ForEach( list, x => list.Remove( x ) );
            Assert.AreSame( list, actual );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ForEachTestCase1NullCheck()
        {
            List<Object> list = null;
            list.ForEach( ( x, i ) => { } );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ForEachTestCase1NullCheck1()
        {
            Action<Object, Int32> action = null;
            new List<Object>().ForEach( action );
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
        [ExpectedException( typeof (InvalidOperationException) )]
        public void ForEachTestCase3()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            list.ForEach( ( x, i ) => list.Remove( x ) );
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ForEachTestCaseNullCheck()
        {
            List<Object> list = null;
            IEnumerableTEx.ForEach( list, Console.WriteLine );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ForEachTestCaseNullCheck1()
        {
            Action<Object> action = null;
            IEnumerableTEx.ForEach( new List<Object>(), action );
        }
    }
}