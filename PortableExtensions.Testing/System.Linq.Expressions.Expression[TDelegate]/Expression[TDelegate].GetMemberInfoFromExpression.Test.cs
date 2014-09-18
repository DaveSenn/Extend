#region Using

using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public class ExpressionTDelegateExTest
    {
        private class TestModel
        {
            public String Name { get; set; }
            public Int32 Age { get; set; }
        }

        [Test]
        public void GetMemberInfoFromExpressionTestCase()
        {
            Expression<Func<TestModel, String>> memberExpression = x => x.Name;
            var actual = memberExpression.GetMemberInfoFromExpression();
            Assert.AreEqual( typeof ( String ), ( actual as PropertyInfo ).PropertyType );

            Expression<Func<TestModel, Object>> memberExpression1 = x => x.Age;
            actual = memberExpression1.GetMemberInfoFromExpression();
            Assert.AreEqual( typeof ( Int32 ), ( actual as PropertyInfo ).PropertyType );

            Expression<Func<TestModel, Int32>> memberExpression2 = x => x.Age;
            actual = memberExpression1.GetMemberInfoFromExpression();
            Assert.AreEqual( typeof ( Int32 ), ( actual as PropertyInfo ).PropertyType );
        }

        [Test]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void GetMemberInfoFromExpressionTestCaseNullCheck()
        {
            Expression<Func<TestModel, Object>> memberExpression = null;
            memberExpression.GetMemberInfoFromExpression();
        }


    }
}

/*
 public static MemberInfo GetMemberInfoFromExpression<TDeclairingType, TMember>(
            this Expression<Func<TDeclairingType, TMember>> memberExpression )
        {
            memberExpression.ThrowIfNull( () => memberExpression );

            var memberSelectorExpression = memberExpression.Body.NodeType == ExpressionType.Convert
                                               ? ( memberExpression.Body as UnaryExpression ).Operand as
                                                 MemberExpression
                                               : memberExpression.Body as MemberExpression;

            return memberSelectorExpression == null ? null : memberSelectorExpression.Member;
        }
 */