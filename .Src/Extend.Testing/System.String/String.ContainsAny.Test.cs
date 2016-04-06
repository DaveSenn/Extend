#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ContainsAnyTest()
        {
            var actual = "test012".ContainsAny( "0", "1", "2", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAnyTest1()
        {
            var actual = "ABC".ContainsAny( StringComparison.OrdinalIgnoreCase, "a", "b", "c", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAnyTest1NullCheck()
        {
            Action test = () => StringEx.ContainsAny( null, StringComparison.CurrentCulture, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTest1NullCheck1()
        {
            Action test = () => "".ContainsAny( StringComparison.CurrentCulture, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestNullCheck()
        {
            Action test = () => StringEx.ContainsAny( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestNullCheck1()
        {
            Action test = () => "".ContainsAny( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}