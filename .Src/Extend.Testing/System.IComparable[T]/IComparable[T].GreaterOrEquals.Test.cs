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
        public void GreaterOrEqualsTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.GreaterOrEquals( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 900;

            actual = value.GreaterOrEquals( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 10;

            actual = value.GreaterOrEquals( value1 );
            Assert.IsTrue( actual );
        }

        [Test]
        public void GreaterOrEqualsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.GreaterOrEquals( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GreaterOrEqualsTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".GreaterOrEquals( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}