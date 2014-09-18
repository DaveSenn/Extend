#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ArrayExTest
    {
        [Test]
        public void ToListTestCase()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            var list = array.ToList( x => "test" + x );

            Assert.AreEqual( "test0", list[0] );
            Assert.AreEqual( "test1", list[1] );
            Assert.AreEqual( "test2", list[2] );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToListTestCaseNullCheck()
        {
            Array array = null;
            array.ToList( x => "test" + x );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ToListTestCaseNullCheck1()
        {
            Array array = new[]
            {
                "0",
                "1",
                "2"
            };
            Func<Object, String> func = null;
            array.ToList( func );
        }
    }
}