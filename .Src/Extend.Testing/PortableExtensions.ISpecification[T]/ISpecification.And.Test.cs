#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    // ReSharper disable once InconsistentNaming
    public partial class ISpecificationExTest
    {
        [Fact]
        public void AndTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            actual.Should()
                  .BeTrue();
        }

        [Fact]
        public void AndTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            actual.Should()
                  .BeFalse();
        }

        [Fact]
        public void AndTest10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.And( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();

            actual.Should()
                  .HaveCount( 1 );
            actual.Should()
                  .Contain( "msgLeft" );
        }

        [Fact]
        public void AndTest11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.And( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();

            actual.Should()
                  .HaveCount( 2 );
            actual.Should()
                  .Contain( "msgLeft", "msgRight" );
        }

        [Fact]
        public void AndTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.False( actual );
        }

        [Fact]
        public void AndTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.False( actual );
        }

        [Fact]
        public void AndTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.Empty( actual );
        }

        [Fact]
        public void AndTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actual );
            Assert.Null( actual[0] );
        }

        [Fact]
        public void AndTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actual );
            Assert.Null( actual[0] );
        }

        [Fact]
        public void AndTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Null( actual[0] );
            Assert.Null( actual[1] );
        }

        [Fact]
        public void AndTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.And( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.Empty( actual );
        }

        [Fact]
        public void AndTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.And( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actual );
            Assert.Equal( "msgRight", actual[0] );
        }

        [Fact]
        public void AndTestNullCheck()
        {
            ISpecification<String> left = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.And( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void AndTestNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.And( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}