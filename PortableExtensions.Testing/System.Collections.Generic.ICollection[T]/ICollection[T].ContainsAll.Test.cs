#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class CollectionTExTest
    {
        [Test]
        public void ContainsAllTestCase()
        {
            var c = new List<String>();
            var valuesToAdd = RandomValueEx.GetRandomStrings( 10 );
            c.AddRange( valuesToAdd );

            Assert.IsTrue( c.ContainsAll( valuesToAdd ) );
            Assert.IsFalse( c.ContainsAll( "test0" ) );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck()
        {
            CollectionTEx.ContainsAll( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck1()
        {
            new List<String>().ContainsAll( null );
        }
    }
}