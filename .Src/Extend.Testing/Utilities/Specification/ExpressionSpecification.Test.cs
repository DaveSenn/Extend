#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public class ExpressionSpecificationTest
    {
        [Test]
        public void AndTestCase()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void AndTestCase1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCase3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestCaseNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            Action test = () => target.And( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTestCaseNulLCheck()
        {
            Action test = () => new ExpressionSpecification<String>( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsSatisfiedByTestCase()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123" );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByTestCase1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123456" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123" )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.IsNull( actual[0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTestCase1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123456" )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void OrTestCase()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTestCase3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void OrTestCaseNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            Action test = () => target.Or( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void XOrTestCase()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCase1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTestCase3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestCaseNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            Action test = () => target.XOr( other );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}