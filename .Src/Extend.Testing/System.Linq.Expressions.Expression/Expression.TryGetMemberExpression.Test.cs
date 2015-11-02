﻿#region Usings

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExpressionExTest
    {
        private event PropertyChangedEventHandler PropertyChanged;

        private class TestModel
        {
            #region Properties

            public Int32 Age { get; set; }
            public SubModel SubModel { get; set; }

            #endregion
        }

        private class SubModel
        {
            #region Properties

            public String Foo { get; set; }

            #endregion
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void GetNameChainOverload1TestCaseNullCheck()
        {
            MemberExpression outResult;
            Expression<Func<Object>> expression = null;
            expression.TryGetMemberExpression( out outResult );
        }

        [Test]
        public void TryGetMemberExpression5()
        {
            MemberExpression outResult;
            var myInt = RandomValueEx.GetRandomInt32();
            Expression<Func<Int32>> expression = () => myInt;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( outResult.Member.Name, "myInt" );
        }

        [Test]
        public void TryGetMemberExpression6()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<Int32>> expression = () => model.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Age", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpression7()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<String>> expression = () => model.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Foo", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpression8()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<Object>> expression = () => model.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Foo", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpression9()
        {
            MemberExpression outResult;
            var model = new TestModel();
            Expression<Func<Object>> expression = () => PropertyChanged;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "PropertyChanged", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpressionTestCase()
        {
            var myInt = RandomValueEx.GetRandomInt32();
            Expression<Func<Int32>> expression = () => myInt;
            MemberExpression outResult;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( outResult.Member.Name, "myInt" );
        }

        [Test]
        public void TryGetMemberExpressionTestCase1()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Int32>> expression = x => x.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( outResult.Member.Name, "Age" );
        }

        [Test]
        public void TryGetMemberExpressionTestCase2()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, String>> expression = x => x.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Foo", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpressionTestCase3()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Object>> expression = x => x.Age;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Age", outResult.Member.Name );
        }

        [Test]
        public void TryGetMemberExpressionTestCase4()
        {
            MemberExpression outResult;
            Expression<Func<TestModel, Object>> expression = x => x.SubModel.Foo;
            var actual = expression.TryGetMemberExpression( out outResult );

            Assert.IsTrue( actual );
            Assert.AreEqual( "Foo", outResult.Member.Name );
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void TryGetMemberExpressionTestCaseNotSupportedException()
        {
            MemberExpression outResult;
            const Int32 myInt = 100;
            Expression<Func<Object, Object>> expression = x => myInt;
            expression.TryGetMemberExpression( out outResult );
        }

        [Test]
        [ExpectedException( typeof (NotSupportedException) )]
        public void TryGetMemberExpressionTestCaseNotSupportedException1()
        {
            MemberExpression outResult;
            const Int32 myInt = 100;
            Expression<Func<Object>> expression = () => myInt;
            expression.TryGetMemberExpression( out outResult );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void TryGetMemberExpressionTestCaseNullCheck()
        {
            MemberExpression outResult;
            Expression<Func<Object, Object>> expression = null;
            expression.TryGetMemberExpression( out outResult );
        }
    }
}