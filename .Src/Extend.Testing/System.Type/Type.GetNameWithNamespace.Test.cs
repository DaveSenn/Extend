#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TypeExTest
    {
        private class TestClass
        {
        }

        // ReSharper disable once UnusedTypeParameter
        private class TestClassGeneric<T>
        {
        }

        [Test]
        public void GetNameWithNamespaceArgumentNullExceptionTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.GetNameWithNamespace();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest()
        {
            var actual = typeof(List<TestClassGeneric<String>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[Extend.Testing.TypeExTest+TestClassGeneric`1[[System.String, mscorlib]], Extend.Testing]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest1()
        {
            var actual = typeof(List<List<String>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest2()
        {
            var actual = typeof(List<List<TypeExTest>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[Extend.Testing.TypeExTest, Extend.Testing]], mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest3()
        {
            var actual = typeof(List<List<TestClass>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest4()
        {
            var actual = typeof(List<List<TestClassGeneric<String>>>).GetNameWithNamespace();

            actual.Should()
                  .Be(
                      "System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[Extend.Testing.TypeExTest+TestClassGeneric`1[[System.String, mscorlib]], Extend.Testing]], mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericNestedTest5()
        {
            var actual = typeof(List<List<Dictionary<String, TestClass>>>).GetNameWithNamespace();

            actual.Should()
                  .Be(
                      "System.Collections.Generic.List`1[[System.Collections.Generic.List`1[[System.Collections.Generic.Dictionary`2[[System.String, mscorlib],[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], mscorlib]], mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericTest()
        {
            var actual = typeof(List<String>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[System.String, mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericTest1()
        {
            var actual = typeof(List<DateTime>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[System.DateTime, mscorlib]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericTest2()
        {
            var actual = typeof(List<TypeExTest>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[Extend.Testing.TypeExTest, Extend.Testing]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceGenericTest3()
        {
            var actual = typeof(List<TestClass>).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Collections.Generic.List`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespacePrivateClassGenericTest()
        {
            var actual = typeof(TestClassGeneric<String>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest+TestClassGeneric`1[[System.String, mscorlib]], Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespacePrivateClassTest()
        {
            var actual = typeof(TestClass).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest+TestClass, Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceSimpleTest()
        {
            var actual = typeof(String).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.String, mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceSimpleTest1()
        {
            var actual = typeof(Int32).GetNameWithNamespace();

            actual.Should()
                  .Be( "System.Int32, mscorlib" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Test]
        public void GetNameWithNamespaceSimpleTest2()
        {
            var actual = typeof(TypeExTest).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest, Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }
    }
}