#region Usings

using System;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class BooleanExTest
    {
        [Fact]
        public void SelectValueTest()
        {
            const String trueValue = "true";
            const String falseValue = "false";

            var actual = false.SelectValue( trueValue, falseValue );
            Assert.Equal( falseValue, actual );

            actual = true.SelectValue( trueValue, falseValue );
            Assert.Equal( trueValue, actual );
        }
    }
}