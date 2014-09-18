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
        [Test]
        public void ContainsAnyTestCase()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( IEnumerableTEx.ContainsAny( list, "test" ) );
            Assert.IsTrue( IEnumerableTEx.ContainsAny( list, "test", "test1" ) );
            Assert.IsTrue( IEnumerableTEx.ContainsAny( list, "test", "test1", "test2" ) );
            Assert.IsFalse( IEnumerableTEx.ContainsAny( list, "asdasd" ) );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCaseNullCheck()
        {
            IEnumerableTEx.ContainsAny( null, new Object(), new Object() );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCaseNullCheck1()
        {
            Object[] array = null;
            new List<String>().ContainsAny( array );
        }

        [Test]
        public void ContainsAnyTestCase1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAny( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAny( new List<String> { "test", "test1" } ) );
            Assert.IsTrue( list.ContainsAny( new List<String> { "test", "test1", "test2" } ) );
            Assert.IsFalse( list.ContainsAny( new List<String> { "asdasd" } ) );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCase1NullCheck()
        {
            IEnumerableTEx.ContainsAny( null, new List<Object>() );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAnyTestCase1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            new List<String>().ContainsAny( enumerable );
        }
    }
}