#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void KeepWhereCaseNullCheck()
        {
            Action test = () => StringEx.KeepWhere( null, x => false );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void KeepWhereTest()
        {
            var actual = "a1-b2.c3".KeepWhere( x => x.IsLetter() || x.IsNumber() );
            Assert.AreEqual( "a1b2c3", actual );
        }

        [Test]
        public void KeepWhereTEstCaseNullCheck1()
        {
            Action test = () => "".KeepWhere( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}