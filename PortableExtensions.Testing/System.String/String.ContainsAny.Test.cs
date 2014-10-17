#region Usings

using System;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ContainsAnyTestCase ()
        {
            var actual = "test012".ContainsAny( "0", "1", "2", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAnyTestCase1 ()
        {
            var actual = "ABC".ContainsAny( StringComparison.OrdinalIgnoreCase, "a", "b", "c", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ContainsAnyTestCase1NullCheck ()
        {
            var actual = StringEx.ContainsAny( null, StringComparison.CurrentCulture, "" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ContainsAnyTestCase1NullCheck1 ()
        {
            var actual = "".ContainsAny( StringComparison.CurrentCulture, null );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ContainsAnyTestCaseNullCheck ()
        {
            var actual = StringEx.ContainsAny( null, "" );
            Assert.IsTrue( actual );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void ContainsAnyTestCaseNullCheck1 ()
        {
            var actual = "".ContainsAny( null );
            Assert.IsTrue( actual );
        }
    }
}