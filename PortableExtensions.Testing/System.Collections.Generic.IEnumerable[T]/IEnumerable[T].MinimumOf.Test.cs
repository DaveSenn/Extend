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
        public void MinimumOfTestCase ()
        {
            var list = new List<String>();
            Assert.IsFalse( list.MinimumOf( 1, x => true ) );
            Assert.IsTrue( list.MinimumOf( 0, x => false ) );
            Assert.IsTrue( list.MinimumOf( 0, x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.MinimumOf( 9, x => true ) );
            Assert.IsTrue( list.MinimumOf( 10, x => true ) );
            Assert.IsFalse( list.MinimumOf( 10, x => false ) );
            Assert.IsFalse( list.MinimumOf( 11, x => true ) );
        }

        [Test]
        public void MinimumOfTestCase1 ()
        {
            var list = new List<String>();
            Assert.IsFalse( list.MinimumOf( 1 ) );
            Assert.IsTrue( list.MinimumOf( 0 ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.IsTrue( list.MinimumOf( 9 ) );
            Assert.IsTrue( list.MinimumOf( 10 ) );
            Assert.IsFalse( list.MinimumOf( 11 ) );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void MinimumOfTestCase1NullCheck ()
        {
            List<Object> list = null;
            list.MinimumOf( 10 );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void MinimumOfTestCaseNullCheck ()
        {
            List<Object> list = null;
            list.MinimumOf( 10, x => true );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void MinimumOfTestCaseNullCheck1 ()
        {
            List<Object> list = null;
            list.MinimumOf( 10, null );
        }
    }
}