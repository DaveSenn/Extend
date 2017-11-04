#region Usings

using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class AssemblyExTest
    {
        [Fact]
        public void GetDefinedTypesNullValueTest()
        {
            Assembly assembly = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => assembly.GetDefinedTypes();

            test.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        ///     TODO: Find a clever way to test this method.
        /// </summary>
        [Fact]
        public void GetDefinedTypesTest()
        {
            var actual = typeof(ActionEx)
                .GetDeclaringAssembly()
                .GetDefinedTypes();

            actual.Any( x => x.Name == typeof(ActionEx).Name )
                  .Should()
                  .BeTrue();
        }
    }
}