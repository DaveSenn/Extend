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
        public void MinimumOfTest()
        {
            var list = new List<String>();
            Assert.False( list.MinimumOf( 1, x => true ) );
            Assert.True( list.MinimumOf( 0, x => false ) );
            Assert.True( list.MinimumOf( 0, x => true ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.True( list.MinimumOf( 9, x => true ) );
            Assert.True( list.MinimumOf( 10, x => true ) );
            Assert.False( list.MinimumOf( 10, x => false ) );
            Assert.False( list.MinimumOf( 11, x => true ) );
        }

        [Fact]
        public void MinimumOfTest1()
        {
            var list = new List<String>();
            Assert.False( list.MinimumOf( 1 ) );
            Assert.True( list.MinimumOf( 0 ) );

            list = RandomValueEx.GetRandomStrings( 10 );
            Assert.True( list.MinimumOf( 9 ) );
            Assert.True( list.MinimumOf( 10 ) );
            Assert.False( list.MinimumOf( 11 ) );
        }

        [Fact]
        public void MinimumOfTest1NullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.MinimumOf( 10 );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MinimumOfTestNullCheck()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.MinimumOf( 10, x => true );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MinimumOfTestNullCheck1()
        {
            List<Object> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => list.MinimumOf( 10,
                                                // ReSharper disable once AssignNullToNotNullAttribute
                                                null );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}