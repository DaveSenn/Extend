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
        public void SubstringLeftTestCase()
        {
            var actual = "testabc".SubstringLeft( 4 );
            Assert.AreEqual( "test", actual );
        }

        [Test]
        public void SubstringLeftTestCaseNullCheck()
        {
            Action test = () => StringEx.SubstringLeft( null, 1 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}