#region Usings

using System;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public partial class TypeExTest
    {
        [Fact]
        public void GetDeclaringAssemblyNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.GetDeclaringAssembly();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetDeclaringAssemblyTest()
        {
            var actual = typeof(ActionEx).GetDeclaringAssembly();
            actual.FullName.Should()
                  .Be( "Extend, Version=1.1.11.0, Culture=neutral, PublicKeyToken=869d4c589c0473ac" );
        }
    }
}