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
        public void GreaterTestCase()
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
        public void GreaterTestCaseNullCheck()
        {
            Action test = () => IComparableTEx.Greater( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GreaterTestCaseNullCheck1()
        {
            Action test = () => "".Greater( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}