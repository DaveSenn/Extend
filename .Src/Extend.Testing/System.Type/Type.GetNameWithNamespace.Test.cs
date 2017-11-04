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
        public void GetNameWithNamespaceArgumentNullExceptionTest()
        {
            Type type = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => type.GetNameWithNamespace();

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest()
        {
            var actual = typeof(TreeNode<IIndexedItem<TestClass>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.IIndexedItem`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest1()
        {
            var actual = typeof(TreeNode<TreeNode<IIndexedItem<TestClass>>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.TreeNode`1[[Extend.IIndexedItem`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest2()
        {
            var actual = typeof(TreeNode<TreeNode<TypeExTest>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.TreeNode`1[[Extend.Testing.TypeExTest, Extend.Testing]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest3()
        {
            var actual = typeof(TreeNode<TreeNode<TestClass>>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest4()
        {
            var actual = typeof(TreeNode<TreeNode<TestClassGeneric<TestClass>>>).GetNameWithNamespace();

            actual.Should()
                  .Be(
                      "Extend.TreeNode`1[[Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClassGeneric`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend.Testing]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericNestedTest5()
        {
            var actual = typeof(TreeNode<TreeNode<TestClassGeneric2<TestClassGeneric2<TestClass, TestClass>, TestClass>>>).GetNameWithNamespace();

            actual.Should()
                  .Be(
                      "Extend.TreeNode`1[[Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClassGeneric2`2[[Extend.Testing.TypeExTest+TestClassGeneric2`2[[Extend.Testing.TypeExTest+TestClass, Extend.Testing],[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend.Testing],[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend.Testing]], Extend]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericTest()
        {
            var actual = typeof(TreeNode<TestClass>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericTest1()
        {
            var actual = typeof(TreeNode<TestClass>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericTest2()
        {
            var actual = typeof(TreeNode<TypeExTest>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.Testing.TypeExTest, Extend.Testing]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceGenericTest3()
        {
            var actual = typeof(TreeNode<TestClass>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.TreeNode`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespacePrivateClassGenericTest()
        {
            var actual = typeof(TestClassGeneric<TestClass>).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest+TestClassGeneric`1[[Extend.Testing.TypeExTest+TestClass, Extend.Testing]], Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespacePrivateClassTest()
        {
            var actual = typeof(TestClass).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest+TestClass, Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceSimpleTest()
        {
            var actual = typeof(ActionEx).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.ActionEx, Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceSimpleTest1()
        {
            var actual = typeof(ArrayEx).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.ArrayEx, Extend" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        [Fact]
        public void GetNameWithNamespaceSimpleTest2()
        {
            var actual = typeof(TypeExTest).GetNameWithNamespace();

            actual.Should()
                  .Be( "Extend.Testing.TypeExTest, Extend.Testing" );

            var actualType = Type.GetType( actual );
            actualType.Should()
                      .NotBeNull();
        }

        #region Nested Types

        private class TestClass
        {
        }

        // ReSharper disable once UnusedTypeParameter
        private class TestClassGeneric<T>
        {
        }

        // ReSharper disable UnusedTypeParameter
        private class TestClassGeneric2<T, T1>
            // ReSharper restore UnusedTypeParameter
        {
        }

        #endregion
    }
}