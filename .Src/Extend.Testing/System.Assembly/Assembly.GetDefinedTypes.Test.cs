#region Usings

using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class AssemblyExTest
    {
        [Test]
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
        [Test]
        public void GetDefinedTypesTest()
        {
            var actual = typeof(String)
                .Assembly.GetDefinedTypes();

            actual.Count()
                  .Should()
                  .Be( 3244 );
        }
    }
}