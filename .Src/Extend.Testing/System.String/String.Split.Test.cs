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
        public void SplitTestCase()
        {
            var actual = "1,2,3".Split( "," );
            Assert.AreEqual( 3, actual.Length );
            Assert.AreEqual( "1", actual[0] );
            Assert.AreEqual( "2", actual[1] );
            Assert.AreEqual( "3", actual[2] );
        }

        [Test]
        public void SplitTestCase1()
        {
            var actual = "1,2,,3.4".Split( StringSplitOptions.RemoveEmptyEntries, ",", "." );
            Assert.AreEqual( 4, actual.Length );
            Assert.AreEqual( "1", actual[0] );
            Assert.AreEqual( "2", actual[1] );
            Assert.AreEqual( "3", actual[2] );
            Assert.AreEqual( "4", actual[3] );
        }

        [Test]
        public void SplitTestCase1NullCheck()
        {
            Action test = () => StringEx.Split( null, StringSplitOptions.RemoveEmptyEntries, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SplitTestCase1NullCheck1()
        {
            Action test = () => "".Split( StringSplitOptions.RemoveEmptyEntries, null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SplitTestCaseNullCheck()
        {
            Action test = () => StringEx.Split( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SplitTestCaseNullCheck1()
        {
            Action test = () => StringEx.Split( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}