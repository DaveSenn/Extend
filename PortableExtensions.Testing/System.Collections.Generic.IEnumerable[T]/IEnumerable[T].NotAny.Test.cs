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
        public void NotAnyTestCase()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void NotAnyTestCaseNullCheck()
        {
            List<Object> list = null;
            list.NotAny();
        }

        [TestCase]
        public void NotAnyTestCase1()
        {
            var list = new List<String>();
            Assert.IsTrue( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.IsFalse( list.NotAny( x => true ) );
            Assert.IsTrue( list.NotAny( x => false ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void NotAnyTestCase1NullCheck()
        {
            List<Object> list = null;
            list.NotAny( x => true );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void NotAnyTestCase1NullCheck1()
        {
            Func<Object, Boolean> func = null;
            new List<Object>().NotAny( func );
        }
    }
}