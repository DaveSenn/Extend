#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void AnyAndNotNullNullCheck1()
        {
            new List<String>().AnyAndNotNull( null );
        }

        [Test]
        public void PathCombineTestCase()
        {
            List<String> list = null;
            Assert.IsFalse( list.AnyAndNotNull() );

            list = new List<String>();
            Assert.IsFalse( list.AnyAndNotNull() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsTrue( list.AnyAndNotNull() );
        }

        [Test]
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
    }
}