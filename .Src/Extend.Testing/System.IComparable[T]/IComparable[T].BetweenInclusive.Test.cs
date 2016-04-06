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
        public void BetweenInclusiveTest()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 300;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );
        }

        [Test]
        public void BetweenInclusiveTest1()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsTrue( actual );
        }

        [Test]
        public void BetweenInclusiveTest2()
        {
            const Int32 value = 100;
            const Int32 min = 50;
            const Int32 max = 99;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTest3()
        {
            const Int32 value = 200;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTest4()
        {
            const Int32 value = 2;
            const Int32 min = 50;
            const Int32 max = 100;

            var actual = value.BetweenInclusive( min, max );
            Assert.IsFalse( actual );
        }

        [Test]
        public void BetweenInclusiveTestNullCheck()
        {
            Action test = () => IComparableTEx.BetweenInclusive( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenInclusiveTestNullCheck1()
        {
            Action test = () => "".BetweenInclusive( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void BetweenInclusiveTestNullCheck2()
        {
            Action test = () => "".BetweenInclusive( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}