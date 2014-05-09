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
        public void CopyTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var destinationArray = new string[3];
            array.Copy( destinationArray, 3 );

            Assert.AreEqual( "0", destinationArray[0] );
            Assert.AreEqual( "1", destinationArray[1] );
            Assert.AreEqual( "2", destinationArray[2] );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CopyAllTestCaseNullCheck()
        {
            Array array = null;
            var destinationArray = new string[10];
            array.Copy( destinationArray, 1 );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void CopyAllTestCaseNullCheck1()
        {
            Array array = new string[10];
            String[] destinationArray = null;
            array.Copy( destinationArray, 1 );
        }
    }
}