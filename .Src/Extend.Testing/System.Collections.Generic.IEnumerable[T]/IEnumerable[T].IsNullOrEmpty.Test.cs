#region Usings

using System;
using System.Collections.Generic;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void IsNullOrEmptyTest()
        {
            List<String> list = null;
            Assert.True( list.IsNullOrEmpty() );

            list = new List<String>();
            Assert.True( list.IsNullOrEmpty() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.False( list.IsNullOrEmpty() );
        }
    }
}