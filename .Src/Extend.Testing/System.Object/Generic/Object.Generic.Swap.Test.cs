#region Usings

using System;
using System.Collections.Generic;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void SwapTest()
        {
            var value0 = new List<String>();
            var value1 = new List<String> { RandomValueEx.GetRandomString() };

            this.Swap( ref value0, ref value1 );
            Assert.Single( value0 );
            Assert.Empty( value1 );
        }

        [Fact]
        public void SwapTest1()
        {
            var value0 = 10;
            var value1 = 100;

            this.Swap( ref value0, ref value1 );
            Assert.Equal( 100, value0 );
            Assert.Equal( 10, value1 );
        }
    }
}