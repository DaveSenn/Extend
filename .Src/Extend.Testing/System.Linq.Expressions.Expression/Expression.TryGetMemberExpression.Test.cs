#region Usings

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    
    public class ExpressionExTest
    {
        [Fact]
        public void TryGetMemberExpressioInvalidTypeTest()
        {
            Expression<Func<String>> func = () => null;
            Expression<Func<String>> func1 = () => "test";
            Expression<Func<String, BinaryExpression>> expression = x => Expression.Coalesce( func, func1 );

            MemberExpression outResult;
            var actual = expression.TryGetMemberExpression( out outResult );
            actual.Should()
                  .BeFalse();
            outResult.Should()
                     .BeNull();
        }

        [Fact]
        public void TryGetMemberExpression5()
        {
            MemberExpression outResult;
            var myInt = RandomValueEx.GetRandomInt32();
            Expression<Func<Int32>> expression = () => myInt;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( outResult.Member.Name, "myInt" );
        }

        [Fact]
        public void TryGetMemberExpression6()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<Int32>> expression = () => model.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Age", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpression7()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<String>> expression = () => model.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Foo", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpression8()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<Object>> expression = () => model.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Foo", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpression9()
        {
            MemberExpression outResult;
            Expression<Func<Object>> expression = () => PropertyChanged;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "PropertyChanged", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpressionTest()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            Expression<Func<Int32>> expression = () => myInt;
            MemberExpression outResult;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( outResult.Member.Name, "myInt" );
        }

        [Fact]
        public void TryGetMemberExpressionTest1()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Int32>> expression = x => x.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( outResult.Member.Name, "Age" );
        }

        [Fact]
        public void TryGetMemberExpressionTest2()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, String>> expression = x => x.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Foo", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpressionTest3()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Object>> expression = x => x.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Age", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpressionTest4()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Object>> expression = x => x.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.True( actual );
            Assert.Equal( "Foo", outResult.Member.Name );
        }

        [Fact]
        public void TryGetMemberExpressionTestNotSupportedException()
        {
            MemberExpression outResult;
            const Int32 myInt = 100;
            Expression<Func<Object, Object>> expression = x => myInt;

            var actual = expression.TryGetMemberExpression( out outResult );
            actual.Should()
                  .BeFalse();
            outResult.Should()
                     .BeNull();
        }

        [Fact]
        public void TryGetMemberExpressionTestNotSupportedException1()
        {
            MemberExpression outResult;
            const Int32 myInt = 100;
            Expression<Func<Object>> expression = () => myInt;

            var actual = expression.TryGetMemberExpression( out outResult );
            actual.Should()
                  .BeFalse();
            outResult.Should()
                     .BeNull();
        }

        [Fact]
        public void TryGetMemberExpressionTestNullCheck()
        {
            MemberExpression outResult;
            Expression<Func<Object, Object>> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expression.TryGetMemberExpression( out outResult );
            test.ShouldThrow<ArgumentNullException>();
        }

        private event PropertyChangedEventHandler PropertyChanged;

        private class TestModel
        {
            #region Properties

            public Int32 Age { get; } = 100;
            public SubModel SubModel { get; } = new SubModel();

            #endregion
        }

        private class SubModel
        {
            #region Properties

            public String Foo { get; } = String.Empty;

            #endregion
        }
    }
}