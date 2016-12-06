#region Usings

using System;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        [Test]
        public void GetDeclaringAssemblyNullTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.GetDeclaringAssembly();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetDeclaringAssemblyTest()
        {
            var actual = typeof(String).GetDeclaringAssembly();
            actual.FullName.Should()
                  .Be( "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" );
        }
    }
}