#region Usings

using System;
using System.Collections.Generic;
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
        public void ToObservableCollectionTest()
        {
            var list = RandomValueEx.GetRandomStrings();
            var actual = list.ToObservableCollection();

            Assert.AreEqual( list.Count, actual.Count );
            for ( var i = 0; i < list.Count; i++ )
                Assert.AreEqual( list[i], actual[i] );
        }

        [Test]
        public void ToObservableCollectionTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.ToObservableCollection();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}