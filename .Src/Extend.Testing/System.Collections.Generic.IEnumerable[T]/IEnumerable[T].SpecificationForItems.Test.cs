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
        public void SpecificationForItemsTest()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3 );

            var result = actual.IsSatisfiedBy( "1234" );
            Assert.True( result );
        }

        [Fact]
        public void SpecificationForItemsTest1()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3 );

            var result = actual.IsSatisfiedBy( "123" );
            Assert.False( result );
        }

        [Fact]
        public void SpecificationForItemsTest2()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3, "msg" );

            var result = actual.IsSatisfiedByWithMessages( "1234" )
                               .ToList();
            Assert.Empty( result );
        }

        [Fact]
        public void SpecificationForItemsTest3()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var targets = new List<String>();
            var actual = targets.SpecificationForItems( x => x.Length > 3, "msg" );

            var result = actual.IsSatisfiedByWithMessages( "123" )
                               .ToList();
            Assert.Single( result );
            Assert.Equal( 1, result.Count( x => x == "msg" ) );
        }

        [Fact]
        public void SpecificationForItemsTestNullCheck()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var targets = new List<String>();
            Func<String, Boolean> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => targets.SpecificationForItems( expression );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}