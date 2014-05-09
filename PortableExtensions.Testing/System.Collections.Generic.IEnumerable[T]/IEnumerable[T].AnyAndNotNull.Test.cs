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
        public void PathCombineTestCase()
        {
            List<String> list = null;
            Assert.IsFalse( list.AnyAndNotNull() );

            list = new List<String>();
            Assert.IsFalse( list.AnyAndNotNull() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.AnyAndNotNull() );
        }

        [TestCase]
        public void PathCombineTestCase1()
        {
            List<String> list = null;
            Assert.IsFalse( list.AnyAndNotNull( x => true ) );

            list = new List<String>();
            Assert.IsFalse( list.AnyAndNotNull( x => true ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.AnyAndNotNull( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.AnyAndNotNull( x => true ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void AnyAndNotNullNullCheck1()
        {
            new List<String>().AnyAndNotNull( null );
        }
    }
}