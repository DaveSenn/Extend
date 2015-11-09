﻿#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void RemoveIfTestCase()
        {
            var list = new List<String>();
            var valueToRemove = RandomValueEx.GetRandomString();
            list.Add( valueToRemove );

            Assert.AreEqual( 1, list.Count );

            var result = list.RemoveIf( valueToRemove, x => false );
            Assert.AreEqual( 1, list.Count );
            Assert.AreSame( list, result );

            list.RemoveIf( valueToRemove, x => true );
            Assert.AreEqual( 0, list.Count );
        }

        [Test]
        public void RemoveIfTestCaseNullCheck()
        {
            Action test = () => CollectionTEx.RemoveIf( null, "", x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RemoveIfTestCaseNullCheck1()
        {
            Action test = () => new List<String>().RemoveIf( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}