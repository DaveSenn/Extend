#region Usings

using System;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ExpressionTDelegateExTest
    {
        [Fact]
        public void GetMemberPathTestFirstLevel()
        {
            Expression<Func<A, B>> expression = x => x.MyB;
            const String expected = "MyB";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestFirstLevelArray()
        {
            Expression<Func<A, Int32[]>> expression = x => x.IntArray;
            const String expected = "IntArray";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestFirstLevelArrayIndex()
        {
            Expression<Func<A, Int32>> expression = x => x.IntArray[2];
            const String expected = "IntArray[2]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestSecondLevel()
        {
            Expression<Func<A, C>> expression = x => x.MyB.MyC;
            const String expected = "MyB.MyC";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestSecondLevelArray()
        {
            Expression<Func<A, String[]>> expression = x => x.MyB.BStrings;
            const String expected = "MyB.BStrings";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestSecondLevelArrayIndex()
        {
            Expression<Func<A, String>> expression = x => x.MyB.BStrings[2];
            const String expected = "MyB.BStrings[2]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestThirdLevel()
        {
            Expression<Func<A, Int32>> expression = x => x.MyB.MyC.MyInt;
            const String expected = "MyB.MyC.MyInt";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestThirdLevelArray()
        {
            Expression<Func<A, String[]>> expression = x => x.MyB.MyC.CStrings;
            const String expected = "MyB.MyC.CStrings";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void GetMemberPathTestThirdLevelArrayIndex()
        {
            Expression<Func<A, String>> expression = x => x.MyB.MyC.CStrings[21];
            const String expected = "MyB.MyC.CStrings[21]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void NullExpression()
        {
            Expression<Func<A, String>> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => expression.GetMemberPath();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TryGetMemberExpressionTestConvert()
        {
            Expression<Func<A, Object>> expression = x => x.IntArray;
            const String expected = "IntArray";
            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void TryGetMemberExpressionTestConvert1()
        {
            Expression<Func<A, Int32>> expression = x => (Int32) x.MyDouble;
            const String expected = "MyDouble";
            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Fact]
        public void UnsupportedExpression()
        {
            Expression<Func<String>> func = () => null;
            Expression<Func<String>> func1 = () => "test";
            Expression<Func<String, BinaryExpression>> expression = x => Expression.Coalesce( func, func1 );

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => expression.GetMemberPath();
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #region Nested Types

        private class A
        {
            #region Properties

            public Int32[] IntArray { get; } = new Int32[0];

            public B MyB { get; } = new B();

            public Double MyDouble { get; } = 100;

            #endregion
        }

        private class B
        {
            #region Properties

            public String[] BStrings { get; } = new String[0];

            public C MyC { get; } = new C();

            #endregion
        }

        private class C
        {
            #region Properties

            public Int32 MyInt { get; } = 100;

            public String[] CStrings { get; } = new String[0];

            #endregion
        }

        #endregion
    }
}