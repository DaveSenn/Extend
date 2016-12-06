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
        public void GetAttributes()
        {
            var actual = typeof(String)
                .Assembly.GetAttributes<AssemblyCompanyAttribute>().ToList();

            actual.Count
                  .Should()
                  .Be( 1 );
            actual.First()
                  .Company.Should()
                  .Be( "Microsoft Corporation" );
        }

        [Test]
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