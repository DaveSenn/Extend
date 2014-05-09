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
        public void ContainsAllTestCase()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( IEnumerableTEx.ContainsAll( list, "test" ) );
            Assert.IsTrue( IEnumerableTEx.ContainsAll( list, "test", "test1" ) );
            Assert.IsFalse( IEnumerableTEx.ContainsAll( list, "test", "test1", "test2" ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck()
        {
            IEnumerableTEx.ContainsAll( null, new Object(), new Object() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck1()
        {
            Object[] array = null;
            IEnumerableTEx.ContainsAll( new List<Object>(), array );
        }

        [TestCase]
        public void ContainsAllTestCase1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAll( list ) );
            Assert.IsFalse( list.ContainsAll( new List<String> { "test", "test1", "test2" } ) );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCase1NullCheck()
        {
            IEnumerableTEx.ContainsAll( null, new List<String>() );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCase1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            IEnumerableTEx.ContainsAll( new List<Object>(), enumerable );
        }
    }
}