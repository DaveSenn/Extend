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
        public void AddIfNotContainsTest()
        {
            var c = new List<String>();

            var result = c.AddIfNotContains( RandomValueEx.GetRandomString() );
            Assert.Single( c );
            Assert.True( result );

            var valueToAdd = RandomValueEx.GetRandomString();
            c.Add( valueToAdd );
            result = c.AddIfNotContains( valueToAdd );
            Assert.Equal( 2, c.Count );
            Assert.False( result );
        }

        [Fact]
        public void AddIfNotContainsTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => CollectionTEx.AddIfNotContains( null, RandomValueEx.GetRandomString() );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}