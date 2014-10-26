#region Usings

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void SatisfiesTestCase()
        {
            var specification = new ExpressionSpecification<String>(x => x.Length > 3);
            var actual = "1234".Satisfies(specification);
            Assert.IsTrue(actual);
        }

        [Test]
        public void SatisfiesTestCase1()
        {
            var specification = new ExpressionSpecification<String>(x => x.Length > 3);
            var actual = "123".Satisfies(specification);
            Assert.IsFalse(actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SatisfiesTestCasenullCheck()
        {
            ISpecification<String> specification = null;
            "1234".Satisfies(specification);
        }
    }
}