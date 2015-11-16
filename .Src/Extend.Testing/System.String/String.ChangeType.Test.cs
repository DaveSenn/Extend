#region Usings

using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class StringExTest
    {
        [Test]
        public void ChangeTypeTestCase()
        {
            var actual = "100".ChangeType( typeof (Int32) );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTestCase1()
        {
            var actual = "100".ChangeType( typeof (Int32), CultureInfo.InvariantCulture );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTestCase1NullCkeck()
        {
            Action test = () => "100".ChangeType( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTestCase1NullCkeck1()
        {
            Action test = () => "100".ChangeType( typeof (Int32), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTestCase2()
        {
            var actual = "100".ChangeType<Int32>();
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTestCase3()
        {
            var actual = "100".ChangeType<Int32>( CultureInfo.InvariantCulture );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTestCase3NullCkeck()
        {
            Action test = () => "100".ChangeType( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTestCaseNullCkeck()
        {
            Action test = () => "100".ChangeType( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}