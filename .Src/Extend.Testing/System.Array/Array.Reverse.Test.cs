#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ReverseTestCase()
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
        public void ReverseTestCase1()
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
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ReverseTestCase1NullCheck()
        {
            Array array = null;
            array.Reverse( 1, 2 );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ReverseTestCaseNullCheck()
        {
            Array array = null;
            array.Reverse();
        }
    }
}