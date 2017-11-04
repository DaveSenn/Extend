#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class LazyExTest
    {
        [Fact]
        public void DisposeIfIsValueCreatedTest()
        {
            var disposable = new Lazy<UnitTestDisposable>( () => new UnitTestDisposable() );
            // ReSharper disable once UnusedVariable
            var value = disposable.Value;

            disposable.DisposeIfIsValueCreated();
            disposable.Value.IsDispose.Should()
                      .BeTrue();
        }

        [Fact]
        public void DisposeIfIsValueCreatedValueNotCreatedTest()
        {
            var disposable = new Lazy<UnitTestDisposable>( () => new UnitTestDisposable() );

            disposable.DisposeIfIsValueCreated();
            disposable.Value.IsDispose.Should()
                      .BeFalse();
        }

        [Fact]
        public void DisposeIfIsValueCreatedValueNullTest()
        {
            Lazy<UnitTestDisposable> disposable = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            disposable.DisposeIfIsValueCreated();
            // ReSharper disable once ExpressionIsAlwaysNull
            disposable.Should()
                      .BeNull();
        }

        #region Nested Types

        private class UnitTestDisposable : IDisposable
        {
            #region Properties

            /// <summary>
            ///     Gets a value indicating whether or not the instnace was disposed.
            /// </summary>
            public Boolean IsDispose { get; private set; }

            #endregion

            #region IDisposable

            /// <summary>
            ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                IsDispose = true;
            }

            #endregion
        }

        #endregion
    }
}