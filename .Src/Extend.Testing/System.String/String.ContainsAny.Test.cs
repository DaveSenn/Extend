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
        public void ContainsAnyTestCase()
        {
            var actual = "test012".ContainsAny( "0", "1", "2", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAnyTestCase1()
        {
            var actual = "ABC".ContainsAny( StringComparison.OrdinalIgnoreCase, "a", "b", "c", "abcd" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAnyTestCase1NullCheck()
        {
            Action test = () => StringEx.ContainsAny( null, StringComparison.CurrentCulture, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCase1NullCheck1()
        {
            Action test = () => "".ContainsAny( StringComparison.CurrentCulture, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCaseNullCheck()
        {
            Action test = () => StringEx.ContainsAny( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAnyTestCaseNullCheck1()
        {
            Action test = () => "".ContainsAny( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}