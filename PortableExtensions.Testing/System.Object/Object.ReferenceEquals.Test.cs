#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void ReferenceEqualsTestCase()
        {
            var list = new List<String>();
            var list1 = new List<String>();

            var actual = list.RefEquals( list );
            Assert.IsTrue( actual );

            actual = list.RefEquals( list1 );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReferenceEqualsTestCaseNullCheck()
        {
            ObjectEx.RefEquals( null, "" );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ReferenceEqualsTestCaseNullCheck1()
        {
            "".RefEquals( null );
        }
    }
}