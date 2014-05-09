#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void ForEachTestCase()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( x => otherList.Contains( x ) ) );
        }

        [TestCase]
        [ExpectedException( typeof ( InvalidOperationException ) )]
        public void ForEachTestCase1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            IEnumerableTEx.ForEach( list, x => list.Remove( x ) );
            Assert.AreEqual( 0, list.Count );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ForEachTestCaseNullCheck()
        {
            List<Object> list = null;
            IEnumerableTEx.ForEach( list, Console.WriteLine );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ForEachTestCaseNullCheck1()
        {
            Action<Object> action = null;
            IEnumerableTEx.ForEach( new List<Object>(), action );
        }

        [TestCase]
        public void ForEachTestCase2()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            IEnumerableTEx.ForEach( list, otherList.Add );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( x => otherList.Contains( x ) ) );
        }

        [TestCase]
        [ExpectedException( typeof ( InvalidOperationException ) )]
        public void ForEachTestCase3()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            list.ForEach( ( x, i ) => list.Remove( x ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ForEachTestCase1NullCheck()
        {
            List<Object> list = null;
            list.ForEach( ( x, i ) => { } );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ForEachTestCase1NullCheck1()
        {
            Action<Object, Int32> action = null;
            new List<Object>().ForEach( action );
        }
    }
}

/*
 public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T, Int32> action)
        {
            enumerable.ThrowIfNull(() => enumerable);
            action.ThrowIfNull(() => action);

            var counter = 0;
            foreach ( var x in enumerable )
            {
                action( x, counter++ );
            }

            return enumerable;
        }
 */