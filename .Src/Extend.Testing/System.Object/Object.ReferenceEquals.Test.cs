#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ReferenceEqualsTest()
        {
            var list = new List<String>();
            var list1 = new List<String>();

            var actual = list.RefEquals( list );
            Assert.IsTrue( actual );

            actual = list.RefEquals( list1 );
            Assert.IsFalse( actual );
        }

        [Test]
        public void ReferenceEqualsTestNullCheck()
        {
            Action test = () => ObjectEx.RefEquals( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ReferenceEqualsTestNullCheck1()
        {
            Action test = () => "".RefEquals( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}