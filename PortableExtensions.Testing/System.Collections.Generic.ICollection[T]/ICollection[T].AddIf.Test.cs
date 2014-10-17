#region Usings

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
        public void AddIfTestCase ()
        {
            var c = new List<String>();

            var result = c.AddIf( x => true, RandomValueEx.GetRandomString() );
            Assert.AreEqual( 1, c.Count );
            Assert.IsTrue( result );

            result = c.AddIf( x => false, RandomValueEx.GetRandomString() );
            Assert.AreEqual( 1, c.Count );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddIfTestCaseNullCheck ()
        {
            List<String> c = null;
            c.AddIf( x => true, RandomValueEx.GetRandomString() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void AddIfTestCaseNullCheck1 ()
        {
            var c = new List<String>();
            c.AddIf( null, RandomValueEx.GetRandomString() );
        }
    }
}