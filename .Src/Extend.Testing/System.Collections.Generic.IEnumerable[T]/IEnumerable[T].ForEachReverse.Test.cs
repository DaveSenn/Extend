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
        public void ForEachReverseTest()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            list.ForEachReverse( otherList.Add );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( x => otherList.Contains( x ) ) );
        }

        [Test]
        public void ForEachReverseTest1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            list.ForEachReverse( x => list.Remove( x ) );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        public void ForEachReverseTestNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.ForEachReverse( Console.WriteLine );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForEachReverseTestNullCheck1()
        {
            Action test = () => new List<Object>().ForEachReverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}