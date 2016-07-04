#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class AssemblyExTest
    {
        [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
        private class FooAttribute : Attribute
        {
            #region Properties

            public String Value { get; set; }

            #endregion
        }

        [Foo( Value = "base" )]
        private class BaseTestClass
        {
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

        [Test]
        public void GetTypesWithAttributeArgumentNullExceptionTest()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => AssemblyEx.GetTypesWithAttribute<FooAttribute>( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetTypesWithAttributeBaseTypeTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( true,
                                                                         typeof(BaseTestClass),
                                                                         GetType()
                                                                             .Assembly );

            actual.Should()
                  .HaveCount( 3 );

            //TestClassA
            var attributes = actual.First( x => x.Type == typeof(TestClassA) )
                                   .Attributes;
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "A" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );

            //TestClassB
            attributes = actual.First( x => x.Type == typeof(TestClassB) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            //TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 3 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }

        [Test]
        public void GetTypesWithAttributeInheriteTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( true,
                                                                         GetType()
                                                                             .Assembly );

            actual.Should()
                  .HaveCount( 5 );

            //BaseTextClass
            var attributes = actual.First( x => x.Type == typeof(BaseTestClass) )
                                   .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            //TestClassA
            attributes = actual.First( x => x.Type == typeof(TestClassA) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "A" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );

            //TestClassB
            attributes = actual.First( x => x.Type == typeof(TestClassB) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            //TestClassC
            attributes = actual.First( x => x.Type == typeof(TestClassC) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.Should()
                      .Contain( x => x.Value == "C" );

            //TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 3 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "base" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }

        [Test]
        public void GetTypesWithAttributeTest()
        {
            var actual = AssemblyEx.GetTypesWithAttribute<FooAttribute>( GetType()
                                                                             .Assembly );

            actual.Should()
                  .HaveCount( 4 );

            //BaseTextClass
            var attributes = actual.First( x => x.Type == typeof(BaseTestClass) )
                                   .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "base" );

            //TestClassA
            attributes = actual.First( x => x.Type == typeof(TestClassA) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "A" );

            //TestClassC
            attributes = actual.First( x => x.Type == typeof(TestClassC) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 1 );
            attributes.First()
                      .Value.Should()
                      .Be( "C" );

            //TestClassD
            attributes = actual.First( x => x.Type == typeof(TestClassD) )
                               .Attributes;
            attributes.Should()
                      .HaveCount( 2 );
            attributes.Should()
                      .Contain( x => x.Value == "D1" );
            attributes.Should()
                      .Contain( x => x.Value == "D2" );
        }
    }
}