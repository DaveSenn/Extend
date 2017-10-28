#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class ExpressionSpecificationTest
    {
        [Fact]
        public void AndTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void AndTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.And( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTestNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.And( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CtorTestNulLCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new ExpressionSpecification<String>( null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsSatisfiedByTest()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123" );
            Assert.False( actual );
        }

        [Fact]
        public void IsSatisfiedByTest1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedBy( "123456" );
            Assert.True( actual );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123" )
                               .ToList();
            Assert.Single( actual );
            Assert.Null( actual[0] );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest1()
        {
            var target = new ExpressionSpecification<String>( x => x.Length > 5 );
            var actual = target.IsSatisfiedByWithMessages( "123456" )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.Or( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void OrTestNullCheck()
        {
            var target = new ExpressionSpecification<String>( x => false );
            ExpressionSpecification<String> other = null;

            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.Or( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void XOrTest()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void XOrTest1()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => true );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void XOrTest2()
        {
            var target = new ExpressionSpecification<String>( x => true );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void XOrTest3()
        {
            var target = new ExpressionSpecification<String>( x => false );
            var other = new ExpressionSpecification<String>( x => false );

            var actual = target.XOr( other );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
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