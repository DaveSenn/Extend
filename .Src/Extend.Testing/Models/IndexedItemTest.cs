#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class IndexedItemTest
    {
        [Test]
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