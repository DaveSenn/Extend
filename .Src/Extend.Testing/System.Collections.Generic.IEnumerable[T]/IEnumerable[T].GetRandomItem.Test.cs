#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class IEnumerableTExTest
    {
        [Fact]
        public void GetRandomItemArgumentNullExceptionTest()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.GetRandomItem();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetRandomItemTest()
        {
            var list = new List<String> { "a", "b", "c", "d" };
            var actual = list.GetRandomItem();

            actual.Should()
                  .NotBeNull();
            list.Should()
                .Contain( actual );
        }
    }
}