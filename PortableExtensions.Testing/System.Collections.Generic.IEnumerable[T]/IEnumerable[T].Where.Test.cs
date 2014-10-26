#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class IEnumerableTExTest
    {
        [Test]
        public void WhereTestCase()
        {
            var target = new List<Int32> {1, 10, 100, 1000};
            var specification = new ExpressionSpecification<Int32>(x => x >= 100);

            var actual = target.Where(specification).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(1, actual.Count(x => x == 100));
            Assert.AreEqual(1, actual.Count(x => x == 1000));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhereTestCaseNullCheck()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            ISpecification<Int32> specification = null;

            target.Where(specification);
        }
    }
}