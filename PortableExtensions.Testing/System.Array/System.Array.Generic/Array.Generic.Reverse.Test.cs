#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [TestCase]
        public void GenericReverseTestCase()
        {
            var array = new[]
            {
                "test",
                "test2"
            };
            array.Reverse();

            Assert.AreEqual( "test2", array[0] );
            Assert.AreEqual( "test", array[1] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericReverseTestCaseNullCheck()
        {
            String[] array = null;
            array.Reverse();
        }

        [TestCase]
        public void GenericReverseTestCase1()
        {
            var array = new[]
            {
                "test",
                "test2",
                "test3"
            };
            array.Reverse( 0, 2 );

            Assert.AreEqual( "test2", array[0] );
            Assert.AreEqual( "test", array[1] );
            Assert.AreEqual( "test3", array[2] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericReverseTestCase1NullCheck()
        {
            String[] array = null;
            array.Reverse( 1, 2 );
        }
    }
}