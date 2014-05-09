#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [TestCase]
        public void ManyTestCase1()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many( x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsFalse( list.Many( x => false ) );
            Assert.IsTrue( list.Many( x => true ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ManyTestCase1NullCheck()
        {
            List<Object> list = null;
            list.Many( x => true );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ManyTestCase1NullCheck1()
        {
            new List<Object>().Many( null );
        }

        [TestCase]
        public void ManyTestCase()
        {
            var list = new List<String>();
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 1 );
            Assert.IsFalse( list.Many() );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.Many() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ManyTestCaseNullCheck()
        {
            List<Object> list = null;
            list.Many();
        }
    }
}