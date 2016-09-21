#region Usings

using System;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ExpressionTDelegateExTest
    {
        [Test]
        public void GetMemberPathTestFirstLevel()
        {
            Expression<Func<A, B>> expression = x => x.MyB;
            const String expected = "MyB";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestFirstLevelArray()
        {
            Expression<Func<A, Int32[]>> expression = x => x.IntArray;
            const String expected = "IntArray";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestFirstLevelArrayIndex()
        {
            Expression<Func<A, Int32>> expression = x => x.IntArray[2];
            const String expected = "IntArray[2]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestSecondLevel()
        {
            Expression<Func<A, C>> expression = x => x.MyB.MyC;
            const String expected = "MyB.MyC";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestSecondLevelArray()
        {
            Expression<Func<A, String[]>> expression = x => x.MyB.BStrings;
            const String expected = "MyB.BStrings";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestSecondLevelArrayIndex()
        {
            Expression<Func<A, String>> expression = x => x.MyB.BStrings[2];
            const String expected = "MyB.BStrings[2]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestThirdLevel()
        {
            Expression<Func<A, Int32>> expression = x => x.MyB.MyC.MyInt;
            const String expected = "MyB.MyC.MyInt";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestThirdLevelArray()
        {
            Expression<Func<A, String[]>> expression = x => x.MyB.MyC.CStrings;
            const String expected = "MyB.MyC.CStrings";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void GetMemberPathTestThirdLevelArrayIndex()
        {
            Expression<Func<A, String>> expression = x => x.MyB.MyC.CStrings[21];
            const String expected = "MyB.MyC.CStrings[21]";

            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void NullExpression()
        {
            Expression<Func<A, String>> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => expression.GetMemberPath();
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TryGetMemberExpressionTestConvert()
        {
            Expression<Func<A, Object>> expression = x => x.IntArray;
            const String expected = "IntArray";
            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void TryGetMemberExpressionTestConvert1()
        {
            Expression<Func<A, Int32>> expression = x => (Int32) x.MyDouble;
            const String expected = "MyDouble";
            var actual = expression.GetMemberPath();

            actual.Should()
                  .Be( expected );
        }

        [Test]
        public void UnsupportedExpression()
        {
            Expression<Func<String>> func = () => null;
            Expression<Func<String>> func1 = () => "test";
            Expression<Func<String, BinaryExpression>> expression = x => Expression.Coalesce( func, func1 );

            Action test = () => expression.GetMemberPath();
            test.ShouldThrow<ArgumentOutOfRangeException>();
        }

        private class A
        {
            #region Properties

            public Int32[] IntArray { get; set; }

            public B MyB { get; set; }

            public Double MyDouble { get; set; }

            #endregion
        }

        private class B
        {
            #region Properties

            public String[] BStrings { get; set; }

            public C MyC { get; set; }

            #endregion
        }

        private class C
        {
            #region Properties

            public Int32 MyInt { get; set; }

            public String[] CStrings { get; set; }

            #endregion
        }
    }
}