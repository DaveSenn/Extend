#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void ReferenceEqualsTestCase()
        {
            var list = new List<String>();
            var list1 = new List<String>();

            var actual = list.RefEquals( list );
            Assert.IsTrue( actual );

            actual = list.RefEquals( list1 );
            Assert.IsFalse( actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ReferenceEqualsTestCaseNullCheck()
        {
            ObjectEx.RefEquals( null, "" );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ReferenceEqualsTestCaseNullCheck1()
        {
            "".RefEquals( null );
        }
    }
}