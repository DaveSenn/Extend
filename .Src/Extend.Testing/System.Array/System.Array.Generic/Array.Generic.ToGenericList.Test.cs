﻿#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void GenericToListTestCase()
        {
            var array = new[]
            {
                1,
                2,
                3
            };
            var list = array.ToGenericList( x => 10 + x );

            Assert.AreEqual( 11, list[0] );
            Assert.AreEqual( 12, list[1] );
            Assert.AreEqual( 13, list[2] );
        }

        [Test]
        public void GenericToListTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => array.ToGenericList( x => x + "Test" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GenericToListTestCaseNullCheck1()
        {
            var array = new[]
            {
                1,
                2,
                3
            };
            Func<Int32, Int32> selector = null;
            Action test = () => array.ToGenericList( selector );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}