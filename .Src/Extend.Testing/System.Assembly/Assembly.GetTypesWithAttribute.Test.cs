#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class AssemblyExTest
    {
        [Fact]
        public void GetTypesWithAttributeArgumentNullExceptionTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => AssemblyEx.GetTypesWithAttribute<FooAttribute>( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetTypesWithAttributeBaseTypeTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( true,
                                                                         typeof(BaseTestClass),
                                                                         GetType()
                                                                             .GetDeclaringAssembly() )
                                   .ToList();

            actual.Should()
                  .HaveCount( 3 );

            // TestClassA
            var attributes = actual.First( x => x.Type == typeof(TestClassA) )
                                   .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "A" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );

            // TestClassB
            attributes = actual.First( x => x.Type == typeof(TestClassB) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            // TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 3 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }

        [Fact]
        public void GetTypesWithAttributeInheriteTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( true,
                                                                         GetType()
                                                                             .GetDeclaringAssembly() )
                                   .ToList();

            actual.Should()
                  .HaveCount( 5 );

            //BaseTextClass
            var attributes = actual.First( x => x.Type == typeof(BaseTestClass) )
                                   .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            // TestClassA
            attributes = actual.First( x => x.Type == typeof(TestClassA) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "A" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );

            // TestClassB
            attributes = actual.First( x => x.Type == typeof(TestClassB) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            // TestClassC
            attributes = actual.First( x => x.Type == typeof(TestClassC) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.Should()
                      .Contain( x => x.Value == "C" );

            // TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 3 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }

        [Fact]
        public void GetTypesWithAttributeTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( GetType()
                                                                             .GetDeclaringAssembly() )
                                   .ToList();

            actual.Should()
                  .HaveCount( 4 );

            //BaseTextClass
            var attributes = actual.First( x => x.Type == typeof(BaseTestClass) )
                                   .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            // TestClassA
            attributes = actual.First( x => x.Type == typeof(TestClassA) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "A" );

            // TestClassC
            attributes = actual.First( x => x.Type == typeof(TestClassC) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "C" );

            // TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes.ToList();
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }

        #region Nested Types

        [Foo( Value = "base" )]
        private class BaseTestClass
        {
        }

        [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
        private class FooAttribute : Attribute
        {
            #region Properties

            public String Value { get; set; }

            #endregion
        }

        [Foo( Value = "A" )]
        private class TestClassA : BaseTestClass
        {
        }

        private class TestClassB : BaseTestClass
        {
        }

        [Foo( Value = "C" )]
        private class TestClassC
        {
        }

        [Foo( Value = "D1" )]
        [Foo( Value = "D2" )]
        private class TestClassD : BaseTestClass
        {
        }

        #endregion
    }
}