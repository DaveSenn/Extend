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
        public void SmallerTest()
        {
            var value = 1000;
            var value1 = 900;

            var actual = value.Smaller( value1 );
            Assert.IsFalse( actual );

            value = 10;
            value1 = 900;

            actual = value.Smaller( value1 );
            Assert.IsTrue( actual );

            value = 10;
            value1 = 10;

            actual = value.Smaller( value1 );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SmallerTestNullCheck()
        {
            Action test = () => IComparableTEx.Smaller( null, "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void SmallerTestNullCheck1()
        {
            Action test = () => "".Smaller( null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}