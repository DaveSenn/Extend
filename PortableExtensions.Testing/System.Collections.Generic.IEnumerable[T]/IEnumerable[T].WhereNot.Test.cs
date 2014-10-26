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
        public void WhereNotTestCase()
        {
            var target = new List<Int32> {1, 10, 100, 1000};
            var specification = new ExpressionSpecification<Int32>(x => x >= 100);

            var actual = target.WhereNot(specification).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(1, actual.Count(x => x == 1));
            Assert.AreEqual(1, actual.Count(x => x == 10));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhereNotTestCaseNullCheck()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            ISpecification<Int32> specification = null;

            target.WhereNot(specification);
        }
    }
}