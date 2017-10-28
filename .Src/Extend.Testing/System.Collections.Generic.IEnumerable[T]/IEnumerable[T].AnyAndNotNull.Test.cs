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
        public void AnyAndNotNullNullCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new List<String>().AnyAndNotNull( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PathCombineTest()
        {
            List<String> list = null;
            Assert.False( list.AnyAndNotNull() );

            list = new List<String>();
            Assert.False( list.AnyAndNotNull() );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.True( list.AnyAndNotNull() );
        }

        [Fact]
        public void PathCombineTest1()
        {
            List<String> list = null;
            Assert.False( list.AnyAndNotNull( x => true ) );

            list = new List<String>();
            Assert.False( list.AnyAndNotNull( x => true ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.False( list.AnyAndNotNull( x => false ) );

            list.Add( RandomValueEx.GetRandomString() );
            Assert.True( list.AnyAndNotNull( x => true ) );
        }
    }
}