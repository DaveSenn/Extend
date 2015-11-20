﻿#region Usings

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
        public void ToObservableCollectionTestCase()
        {
            var list = RandomValueEx.GetRandomStrings();
            var actual = list.ToObservableCollection();

            Assert.AreEqual( list.Count, actual.Count );
            for ( var i = 0; i < list.Count; i++ )
                Assert.AreEqual( list[i], actual[i] );
        }

        [Test]
        public void ToObservableCollectionTestCaseNullCheck()
        {
            List<Object> list = null;
            Action test = () => list.ToObservableCollection();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}