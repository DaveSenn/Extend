#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class CollectionTExTest
    {
        [Fact]
        public void RemoveIfTest()
        {
            var list = new List<String>();
            var valueToRemove = RandomValueEx.GetRandomString();
            list.Add( valueToRemove );

            Assert.Single( list );

            var result = list.RemoveIf( valueToRemove, x => false );
            Assert.Single( list );
            Assert.Same( list, result );

            list.RemoveIf( valueToRemove, x => true );
            Assert.Empty( list );
        }

        [Fact]
        public void RemoveIfTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.RemoveIf( null, "", x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RemoveIfTestNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => new List<String>().RemoveIf( "", null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}