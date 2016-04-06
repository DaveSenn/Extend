#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ReverseTest()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Reverse();

            Assert.AreEqual( "2", array.GetValue( 0 ) );
            Assert.AreEqual( "1", array.GetValue( 1 ) );
            Assert.AreEqual( "0", array.GetValue( 2 ) );
        }

        [Test]
        public void ReverseTest1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.Reverse( 1, 2 );

            Assert.AreEqual( "0", array.GetValue( 0 ) );
            Assert.AreEqual( "2", array.GetValue( 1 ) );
            Assert.AreEqual( "1", array.GetValue( 2 ) );
        }

        [Test]
        public void ReverseTest1NullCheck()
        {
            Array array = null;
            Action test = () => array.Reverse( 1, 2 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ReverseTestNullCheck()
        {
            Array array = null;
            Action test = () => array.Reverse();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}