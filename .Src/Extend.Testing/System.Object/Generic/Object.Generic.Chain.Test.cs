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
        public void ChainTest()
        {
            var list = new List<String>();
            var actual = list.Chain( x => x.Add( "Test1" ) );
            list.Chain( x => x.Add( "Test2" ) );
            list.Chain( x => x.Add( "Test3" ) );

            Assert.AreSame( list, actual );
            Assert.AreEqual( 3, list.Count );
        }

        [Test]
        public void ChainTestNullCheck()
        {
            Action test = () => new List<String>().Chain( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChainTestNullCheck1()
        {
            List<String> list = null;
            Action test = () => list.Chain( x => { } );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}