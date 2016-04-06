#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void SpecificationTest()
        {
            var target = 11;
            var actual = target.Specification( x => x > 10 && x < 200 );

            var result = actual.IsSatisfiedBy( target );
            Assert.IsTrue( result );

            target = 200;
            result = actual.IsSatisfiedBy( target );
            Assert.IsFalse( result );
        }

        [Test]
        public void SpecificationTestNullCheck()
        {
            Func<Int32, Boolean> expression = null;
            Action test = () => 11.Specification( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}