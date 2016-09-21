#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ComparableTExTest
    {
        [Test]
        public void GreaterTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Greater( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 900;

            actual = value.Greater( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 10;

            actual = value.Greater( value1 );
            Assert.IsFalse( actual );
        }

        [Test]
        public void GreaterTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.Greater( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GreaterTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Greater( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}