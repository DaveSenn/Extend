#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void ContainsAllTestCase()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( "test" ) );
            Assert.IsTrue( list.ContainsAll( "test", "test1" ) );
            Assert.IsFalse( list.ContainsAll( "test", "test1", "test2" ) );
        }

        [Test]
        public void ContainsAllTestCase1()
        {
            var list = new List<String> { "test", "test1" };

            Assert.IsTrue( list.ContainsAll( new List<String> { "test" } ) );
            Assert.IsTrue( list.ContainsAll( list ) );
            Assert.IsFalse( list.ContainsAll( new List<String> { "test", "test1", "test2" } ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ContainsAllTestCase1NullCheck()
        {
            IEnumerableTEx.ContainsAll( null, new List<String>() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ContainsAllTestCase1NullCheck1()
        {
            IEnumerable<Object> enumerable = null;
            new List<Object>().ContainsAll( enumerable );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ContainsAllTestCaseNullCheck()
        {
            IEnumerableTEx.ContainsAll( null, new Object(), new Object() );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void ContainsAllTestCaseNullCheck1()
        {
            Object[] array = null;
            new List<Object>().ContainsAll( array );
        }
    }
}