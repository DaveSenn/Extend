#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [TestCase]
        public void RemoveWhereTestCase()
        {
            var actual = "a1-b2.c3".RemoveWhere( x => x.IsNumber() );
            Assert.AreEqual( "a-b.c", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveWhereTestCaseNullCheck()
        {
            StringEx.RemoveWhere( null, x => false );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveWhereTestCaseNullCheck1()
        {
            "".RemoveWhere( null );
        }
    }
}