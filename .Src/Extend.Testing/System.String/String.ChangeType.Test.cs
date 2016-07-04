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
        public void ChangeTypeTest()
        {
            var actual = "100".ChangeType( typeof(Int32) );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTest1()
        {
            var actual = "100".ChangeType( typeof(Int32), CultureInfo.InvariantCulture );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTest1NullCkeck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ChangeType( null, CultureInfo.InvariantCulture );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTest1NullCkeck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ChangeType( typeof(Int32), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTest2()
        {
            var actual = "100".ChangeType<Int32>();
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTest3()
        {
            var actual = "100".ChangeType<Int32>( CultureInfo.InvariantCulture );
            Assert.AreEqual( 100, actual );
        }

        [Test]
        public void ChangeTypeTest3NullCkeck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ChangeType( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ChangeTypeTestNullCkeck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "100".ChangeType( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}