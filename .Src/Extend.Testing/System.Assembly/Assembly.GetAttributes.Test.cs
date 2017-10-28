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
        public void GetAttributes()
        {
            var actual = typeof(String)
                .GetDeclaringAssembly()
                .GetAttributes<AssemblyCompanyAttribute>()
                .ToList();

            actual.Count
                  .Should()
                  .Be( 1 );
            actual.First()
                  .Company.Should()
                  .Be( "Microsoft Corporation" );
        }

        [Fact]
        public void GetAttributesNullValueTest()
        {
            Assembly assembly = null;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => assembly.GetAttributes<AssemblyCompanyAttribute>();

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}