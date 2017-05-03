#region Usings

#region Usings

using System;
using System.Linq.Expressions;
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
        public void ThrowIfNullTest()
        {
            var varName = RandomValueEx.GetRandomString();
#pragma warning disable CS0618 // Type or member is obsolete
            // ReSharper disable once AccessToModifiedClosure
            varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete

            varName = null;
            var errorMessage = String.Empty;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                // ReSharper disable once ExpressionIsAlwaysNull
                varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.True( errorMessage.Contains( "varName" ) );
        }

        [Fact]
        public void ThrowIfNullTest1()
        {
            var varName = RandomValueEx.GetRandomString();
#pragma warning disable CS0618 // Type or member is obsolete
            // ReSharper disable once AccessToModifiedClosure
            varName.ThrowIfNull( () => varName );
#pragma warning restore CS0618 // Type or member is obsolete

            varName = null;
            var expectedErrorMessage = RandomValueEx.GetRandomString();
            var errorMessage = String.Empty;
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                // ReSharper disable once ExpressionIsAlwaysNull
                varName.ThrowIfNull( () => varName, expectedErrorMessage );
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch ( ArgumentNullException ex )
            {
                errorMessage = ex.Message;
            }

            Assert.True( errorMessage.Contains( expectedErrorMessage ) );
        }

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

            Assert.True( errorMessage.Contains( "varName" ) );
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

            Assert.True( errorMessage.Contains( expectedErrorMessage ) );
        }

        [Fact]
        public void ThrowIfNullTestNullCheck()
        {
            String value = null;
#pragma warning disable CS0618 // Type or member is obsolete
            // ReSharper disable once ExpressionIsAlwaysNull
            Action test = () => value.ThrowIfNull( () => value );
#pragma warning restore CS0618 // Type or member is obsolete

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfNullTestNullCheck1()
        {
            String value = null;
            Expression<Func<String>> expression = null;
#pragma warning disable CS0618 // Type or member is obsolete
            // ReSharper disable ExpressionIsAlwaysNull
            Action test = () => value.ThrowIfNull( expression );
            // ReSharper restore ExpressionIsAlwaysNull
#pragma warning restore CS0618 // Type or member is obsolete

            test.ShouldThrow<ArgumentNullException>();
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