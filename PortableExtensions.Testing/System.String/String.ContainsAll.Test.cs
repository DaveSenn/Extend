#region Using

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ContainsAllTestCase()
        {
            var actual = "test012".ContainsAll( "0", "1", "2" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck()
        {
            var actual = StringEx.ContainsAll( null, "" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCaseNullCheck1()
        {
            var actual = "".ContainsAll( null );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAllTestCase1()
        {
            var actual = "ABC".ContainsAll( StringComparison.OrdinalIgnoreCase, "a", "b", "c" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCase1NullCheck()
        {
            var actual = StringEx.ContainsAll( null, StringComparison.CurrentCulture, "" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void ContainsAllTestCase1NullCheck1()
        {
            var actual = "".ContainsAll( StringComparison.CurrentCulture, null );
            Assert.IsTrue( actual );
        }
    }
}