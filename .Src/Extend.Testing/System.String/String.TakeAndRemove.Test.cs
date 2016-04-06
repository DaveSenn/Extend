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
        public void TakeAndRemoveTest()
        {
            var value = "Test";
            var actual = 2.TakeAndRemove( ref value );

            Assert.AreEqual( "Te", actual );
            Assert.AreEqual( "st", value );
        }

        [Test]
        public void TakeAndRemoveTest1()
        {
            var value = "Test";
            var actual = 4.TakeAndRemove( ref value );

            Assert.AreEqual( "Test", actual );
            Assert.AreEqual( String.Empty, value );
        }

        [Test]
        public void TakeAndRemoveTest2()
        {
            var value = "    ";
            var actual = 2.TakeAndRemove( ref value );

            Assert.AreEqual( "  ", actual );
            Assert.AreEqual( "  ", value );
        }

        [Test]
        public void TakeAndRemoveTestArgumentOutOfRangeException()
        {
            var value = "Test";
            Action test = () => 5.TakeAndRemove( ref value );

            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TakeAndRemoveTestNullCheck()
        {
            String value = null;
            Action test = () => 2.TakeAndRemove( ref value );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}