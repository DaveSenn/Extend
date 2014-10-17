#region Usings

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
        [Test]
        public void ForEachReverseTestCase ()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            list.ForEachReverse( otherList.Add );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( x => otherList.Contains( x ) ) );
        }

        [Test]
        public void ForEachReverseTestCase1 ()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            list.ForEachReverse( x => list.Remove( x ) );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ForEachReverseTestCaseNullCheck ()
        {
            List<Object> list = null;
            list.ForEachReverse( Console.WriteLine );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ForEachReverseTestCaseNullCheck1 ()
        {
            new List<Object>().ForEachReverse( null );
        }
    }
}