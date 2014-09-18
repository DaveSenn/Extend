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
        public void ContainsAnyTestCase()
        {
            var c = new List<String>();
            var valuesToAdd = RandomValueEx.GetRandomStrings( 10 );
            c.AddRange( valuesToAdd );

            valuesToAdd.Add( "test0" );
            Assert.IsTrue( c.ContainsAny( valuesToAdd ) );
            Assert.IsFalse( c.ContainsAny( "test0", "test1" ) );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCaseNullCheck()
        {
            CollectionTEx.ContainsAny( null, "test0", "test1", "test2" );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCaseNullCheck1()
        {
            new List<String>().ContainsAny( null );
        }
    }
}