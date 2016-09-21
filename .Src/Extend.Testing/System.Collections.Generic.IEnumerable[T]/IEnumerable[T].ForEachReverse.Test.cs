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
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ForEachReverseTest()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );
            var otherList = new List<String>();

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            list.ForEachReverse( otherList.Add );
            Assert.AreEqual( list.Count, otherList.Count );
            Assert.IsTrue( list.All( x => otherList.Contains( x ) ) );
        }

        [Test]
        public void ForEachReverseTest1()
        {
            var list = RandomValueEx.GetRandomStrings( 10 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            list.ForEachReverse( x => list.Remove( x ) );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        public void ForEachReverseTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ForEachReverse( Console.WriteLine );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ForEachReverseTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<Object>().ForEachReverse( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}