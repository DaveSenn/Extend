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

            Assert.Equal( 1, list.Count );

            var result = list.RemoveIf( valueToRemove, x => false );
            Assert.Equal( 1, list.Count );
            Assert.Same( list, result );

            list.RemoveIf( valueToRemove, x => true );
            Assert.Equal( 0, list.Count );
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