#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Test]
        public void WhereCollectionNullTest()
        {
            List<Int32> target = null;
            var specification = new ExpressionSpecification<Int32>( x => x >= 100 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.Where( specification );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhereSpecificationNullTest()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            ISpecification<Int32> specification = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.Where( specification );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhereTest()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            var specification = new ExpressionSpecification<Int32>( x => x >= 100 );

            var actual = target.Where( specification )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == 100 ) );
            Assert.AreEqual( 1, actual.Count( x => x == 1000 ) );
        }
    }
}