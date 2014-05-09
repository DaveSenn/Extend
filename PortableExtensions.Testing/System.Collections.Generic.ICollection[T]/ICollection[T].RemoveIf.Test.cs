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
        [TestCase]
        public void RemoveIfTestCase()
        {
            var list = new List<String>();
            var valueToRemove = RandomValueEx.GetRandomString();
            list.Add( valueToRemove );

            Assert.AreEqual( 1, list.Count );

            var result = list.RemoveIf( valueToRemove, x => false );
            Assert.AreEqual( 1, list.Count );
            Assert.AreSame( list, result );

            list.RemoveIf( valueToRemove, x => true );
            Assert.AreEqual( 0, list.Count );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveIfTestCaseNullCheck()
        {
            CollectionTEx.RemoveIf( null, "", x => true );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void RemoveIfTestCaseNullCheck1()
        {
            new List<String>().RemoveIf( "", null );
        }
    }
}