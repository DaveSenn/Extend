#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void RemoveWhereTestCase()
        {
            var actual = "a1-b2.c3".RemoveWhere( x => x.IsNumber() );
            Assert.AreEqual( "a-b.c", actual );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveWhereTestCaseNullCheck()
        {
            StringEx.RemoveWhere( null, x => false );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void RemoveWhereTestCaseNullCheck1()
        {
            "".RemoveWhere( null );
        }
    }
}