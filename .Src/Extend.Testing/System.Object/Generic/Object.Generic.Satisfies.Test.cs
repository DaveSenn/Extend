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
        public void SatisfiesTest()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "1234".Satisfies( specification );
            Assert.IsTrue( actual );
        }

        [Test]
        public void SatisfiesTest1()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 );
            var actual = "123".Satisfies( specification );
            Assert.IsFalse( actual );
        }

        [Test]
        public void SatisfiesTestnullCheck()
        {
            ISpecification<String> specification = null;
            Action test = () => "1234".Satisfies( specification );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}