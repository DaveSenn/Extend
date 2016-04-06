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
        public void SubstringLeftSafeTest()
        {
            var actual = "testabc".SubstringLeftSafe( 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSafe( 400 );
            Assert.AreEqual( "testabc", actual );

            actual = "".SubstringLeftSafe( 4 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void SubstringLeftSafeTest1()
        {
            var actual = "123test123".SubstringLeftSafe( 3, 4 );
            Assert.AreEqual( "test", actual );

            actual = "testabc".SubstringLeftSafe( 0, 400 );
            Assert.AreEqual( "testabc", actual );

            actual = "123tes".SubstringLeftSafe( 3, 4 );
            Assert.AreEqual( "tes", actual );

            actual = "".SubstringLeftSafe( 0, 4 );
            Assert.AreEqual( "", actual );

            actual = "".SubstringLeftSafe( 2, 4 );
            Assert.AreEqual( "", actual );
        }

        [Test]
        public void SubstringLeftSafeTest1NullCheck()
        {
            Action test = () => StringEx.SubstringLeftSafe( null, 1, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SubstringLeftSafeTestNullCheck()
        {
            Action test = () => StringEx.SubstringLeftSafe( null, 5 );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}