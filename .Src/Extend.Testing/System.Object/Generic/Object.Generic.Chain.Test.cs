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
        public void ChainTestCase()
        {
            var list = new List<String>();
            var actual = list.Chain( x => x.Add( "Test1" ) );
            list.Chain( x => x.Add( "Test2" ) );
            list.Chain( x => x.Add( "Test3" ) );

            Assert.AreSame( list, actual );
            Assert.AreEqual( 3, list.Count );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ChainTestCaseNullCheck()
        {
            new List<String>().Chain( null );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ChainTestCaseNullCheck1()
        {
            List<String> list = null;
            list.Chain( x => { } );
        }
    }
}