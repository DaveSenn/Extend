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
        public void AndTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void AndTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void AndTestNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.And( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CtorTestNulLCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new ExpressionSpecification<String>( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsSatisfiedByTest()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123" );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsSatisfiedByTest1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123456" );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTest()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123" )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.IsNull( actual[0] );
        }

        [Test]
        public void IsSatisfiedByWithMessagesTest1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123456" )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void OrTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void OrTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void OrTestNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.Or( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void XOrTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( result );
        }

        [Test]
        public void XOrTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( result );
        }

        [Test]
        public void XOrTestNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.XOr( other );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}