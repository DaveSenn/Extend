#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void WhereNotCollectionNullTest()
        {
            List<Int32> target = null;
            var specification = new ExpressionSpecification<Int32>( x => x >= 100 );

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.WhereNot( specification );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WhereNotSpecificationNullTest()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            ISpecification<Int32> specification = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => target.WhereNot( specification );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WhereNotTest()
        {
            var target = new List<Int32> { 1, 10, 100, 1000 };
            var specification = new ExpressionSpecification<Int32>( x => x >= 100 );

            var actual = target.WhereNot( specification )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x == 1 ) );
            Assert.Equal( 1, actual.Count( x => x == 10 ) );
        }
    }
}