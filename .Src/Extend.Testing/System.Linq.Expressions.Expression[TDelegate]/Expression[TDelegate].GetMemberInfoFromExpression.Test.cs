#region Usings

using System;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ExpressionTDelegateExTest
    {
        [Fact]
        public void GetMemberInfoFromExpressionTest()
        {
            Expression<Func<TestModel, String>> memberExpression = x => x.Name;
            var actual = memberExpression.GetMemberInfoFromExpression();
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal( typeof(String), ( actual as PropertyInfo ).PropertyType );

            Expression<Func<TestModel, Object>> memberExpression1 = x => x.Age;
            actual = memberExpression1.GetMemberInfoFromExpression();
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal( typeof(Int32), ( actual as PropertyInfo ).PropertyType );

            actual = memberExpression1.GetMemberInfoFromExpression();
            // ReSharper disable once PossibleNullReferenceException
            Assert.Equal( typeof(Int32), ( actual as PropertyInfo ).PropertyType );
        }

        [Fact]
        public void GetMemberInfoFromExpressionTestNullCheck()
        {
            Expression<Func<TestModel, Object>> memberExpression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => memberExpression.GetMemberInfoFromExpression();

            test.ShouldThrow<ArgumentNullException>();
        }

        #region Nested Types

        private class TestModel
        {
            #region Properties

            public String Name { get; } = String.Empty;
            public Int32 Age { get; } = 100;

            #endregion
        }

        #endregion
    }
}