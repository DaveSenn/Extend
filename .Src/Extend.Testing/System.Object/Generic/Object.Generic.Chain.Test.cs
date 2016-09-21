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
            var actual = list.Chain( x => x.Add( "Test1" ) )
                             .Chain( x => x.Add( "Test2" ) )
                             .Chain( x => x.Add( "Test3" ) );

            Assert.AreSame( list, actual );
            Assert.AreEqual( 3, list.Count );
        }

        [Test]
        public void ChainTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new List<String>().Chain( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}