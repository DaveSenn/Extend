#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class IndexedItemTest
    {
        [Fact]
        public void CtorTest()
        {
            var index = RandomValueEx.GetRandomInt32();
            var value = RandomValueEx.GetRandomString();
            var target = new IndexedItem<String>( index, value );

            target.Index.Should()
                  .Be( index );
            target.Item.Should()
                  .Be( value );
        }
    }
}