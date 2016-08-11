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
        public void BetweenTest()
        {
            var value = 100;
            var min = 50;
            var max = 300;

            var actual = value.Between( min, max );
            Assert.IsTrue( actual );

            value = 100;
            min = 50;
            max = 100;

            actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTest1()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTest3()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTest4()
        {
            const Int32 value = 4;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.Between( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => IComparableTEx.Between( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenTestNullCheck1()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Between( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenTestNullCheck2()
        {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".Between( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}