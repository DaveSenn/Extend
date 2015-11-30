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
        public void AppendArgumentNullExceptionTest()
        {
            List<String> list = null;
            Action test = () => list.Append( "d" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AppendTest()
        {
            var list = new List<String> { "a", "b", "c" };
            var actual = list.Append( "d" );

            list.Should()
                .HaveCount( 3 );
            actual.Should()
                  .Contain( "d" );
            actual.ElementAt( 3 )
                  .Should()
                  .Be( "d" );
        }
    }
}