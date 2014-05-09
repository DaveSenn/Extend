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
        public void KeepWhereTestCase()
        {
            var actual = "a1-b2.c3".KeepWhere( x => x.IsLetter() || x.IsNumber() );
            Assert.AreEqual( "a1b2c3", actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void KeepWhereCaseNullCheck()
        {
            StringEx.KeepWhere( null, x => false );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void KeepWhereTEstCaseNullCheck1()
        {
            "".KeepWhere( null );
        }
    }
}