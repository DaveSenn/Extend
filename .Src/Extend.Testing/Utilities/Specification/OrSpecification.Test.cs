﻿#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class OrSpecificationTest
    {
        [Test]
        public void AndTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new OrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void AndTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new OrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void AndTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCaseNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            Action test = () => target.And( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTestCaseNulLCheck()
        {
            Action test = () => new OrSpecification<String>( new ExpressionSpecification<String>( x => true ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTestCaseNulLCheck1()
        {
            Action test = () => new OrSpecification<String>( null, new ExpressionSpecification<String>( x => true ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsSatisfiedByTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCas4()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase5()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase6()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase7()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new OrSpecification<String>( left, right );
            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void OrTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new OrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new OrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void OrTestCaseNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new OrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            Action test = () => target.Or( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void XOrTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCaseNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            Action test = () => target.XOr( other );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}