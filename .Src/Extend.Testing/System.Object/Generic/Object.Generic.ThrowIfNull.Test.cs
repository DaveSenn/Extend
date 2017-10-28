#region Usings

#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

#pragma warning disable 618

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void ThrowIfNullTest2()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( "varName" );

            varName = null;
            var errorMessage = String.Empty;
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                varName.ThrowIfNull( "varName" );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.Contains( "varName", errorMessage );
        }

        [Fact]
        public void ThrowIfNullTest3()
        {
            var varName = RandomValueEx.GetRandomString();
            varName.ThrowIfNull( "varName" );

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                varName.ThrowIfNull( "varName", expectedErrorMessage );
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.Contains( expectedErrorMessage, errorMessage );
        }

        [Fact]
        public void ThrowIfNullTestNullCheck2()
        {
            String value = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => value.ThrowIfNull( "varName" );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}