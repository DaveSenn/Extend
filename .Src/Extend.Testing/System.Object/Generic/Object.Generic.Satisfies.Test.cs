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
        public void SatisfiesTestCase()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "1234".Satisfies( specification );
            Assert.IsTrue( actual );
        }

        [Test]
        public void SatisfiesTestCase1()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "123".Satisfies( specification );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SatisfiesTestCasenullCheck()
        {
            ISpecification<String> specification = null;
            Action test = () => "1234".Satisfies( specification );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}