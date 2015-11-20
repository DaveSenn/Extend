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
        public void ContainsAllTestCase()
        {
            var actual = "test012".ContainsAll( "0", "1", "2" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAllTestCase1()
        {
            var actual = "ABC".ContainsAll( StringComparison.OrdinalIgnoreCase, "a", "b", "c" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void ContainsAllTestCase1NullCheck()
        {
            Action test = () => StringEx.ContainsAll( null, StringComparison.CurrentCulture, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCase1NullCheck1()
        {
            Action test = () => "".ContainsAll( StringComparison.CurrentCulture, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCaseNullCheck()
        {
            Action test = () => StringEx.ContainsAll( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ContainsAllTestCaseNullCheck1()
        {
            Action test = () => "".ContainsAll( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}