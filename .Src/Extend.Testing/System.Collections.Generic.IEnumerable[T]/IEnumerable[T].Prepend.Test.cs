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
    public partial class IEnumerableTExTest
    {
        [Test]
        public void PrependArgumentNullExceptionTest()
        {
            List<String> list = null;
            Action test = () => list.Prepend( "d" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void PrependTest()
        {
            var list = new List<String> { "a", "b", "c" };
            var actual = list.Prepend( "d" );

            list.Should()
                .HaveCount( 3 );
            actual.Should()
                  .Contain( "d" );
            actual.ElementAt( 0 )
                  .Should()
                  .Be( "d" );
        }
    }
}