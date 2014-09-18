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
        public void GenericToListTestCase()
        {
            var array = new[]
            {
                "0",
                "1",
                "2"
            };
            var list = ( (Array) array ).ToList( x => "test" + x );

            Assert.AreEqual( "test0", list[0] );
            Assert.AreEqual( "test1", list[1] );
            Assert.AreEqual( "test2", list[2] );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericToListTestCaseNullCheck()
        {
            String[] array = null;
            ( (Array) array ).ToList( x => "test" + x );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GenericToListTestCaseNullCheck1()
        {
            var array = new[]
            {
                "0",
                "1",
                "2"
            };
            array.ToList<string>( null );
        }
    }
}