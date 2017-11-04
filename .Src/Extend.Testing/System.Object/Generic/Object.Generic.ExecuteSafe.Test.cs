#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ExecuteSafeTest()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x => throw new InvalidOperationException( expectedValue ) );

            Assert.Null( actual.Result );
            Assert.NotNull( actual.Exception );
            Assert.Equal( expectedValue, actual.Exception.Message );

            var list = new List<String>();
            Assert.True( list.NotAny() );
            actual = expectedValue.ExecuteSafe( list.Add );

            Assert.Null( actual.Exception );
            Assert.Equal( expectedValue, actual.Result );
            Assert.Equal( list[0], expectedValue );
        }

        [Fact]
        public void ExecuteSafeTest1()
        {
            var expectedValue = RandomValueEx.GetRandomString();
            var actual = expectedValue.ExecuteSafe( x =>
            {
                if ( expectedValue.Length > 0 )
                    throw new InvalidOperationException( expectedValue );
                return expectedValue;
            } );

            Assert.Null( actual.Result );
            Assert.NotNull( actual.Exception );
            Assert.Equal( expectedValue, actual.Exception.Message );

            actual = expectedValue.ExecuteSafe( x => expectedValue );

            Assert.Null( actual.Exception );
            Assert.Equal( actual.Result, expectedValue );
        }

        [Fact]
        public void ExecuteSafeTest1NullCheck()
        {
            Func<String, String> func = null;
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => "".ExecuteSafe( func );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ExecuteSafeTestNullCheck()
        {
            Action<String> action = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".ExecuteSafe( action );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}