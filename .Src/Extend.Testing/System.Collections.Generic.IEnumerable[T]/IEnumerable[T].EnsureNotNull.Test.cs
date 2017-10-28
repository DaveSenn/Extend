#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void EnsureNotNullTest()
        {
            List<String> list = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = list.EnsureNotNull();

            Assert.NotNull( actual );
            Assert.Empty( actual );
            Assert.Null( list );
        }

        [Fact]
        public void EnsureNotNullTest1()
        {
            var list = new List<String>
            {
                "1",
                "2",
                "3"
            };
            var actual = list.EnsureNotNull();
            var actualList = actual.ToList();

            Assert.Equal( 3, actualList.Count );
            Assert.Equal( "1", actualList.ElementAt( 0 ) );
            Assert.Equal( "2", actualList.ElementAt( 1 ) );
            Assert.Equal( "3", actualList.ElementAt( 2 ) );
            Assert.Same( list, actual );
        }
    }
}