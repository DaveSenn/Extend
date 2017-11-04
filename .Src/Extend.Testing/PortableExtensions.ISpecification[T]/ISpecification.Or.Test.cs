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
        public void OrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.True( actual );
        }

        [Fact]
        public void OrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.True( actual );
        }

        [Fact]
        public void OrTest10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.Equal( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Fact]
        public void OrTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.True( actual );
        }

        [Fact]
        public void OrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.False( actual );
        }

        [Fact]
        public void OrTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Null( actual[0] );
            Assert.Null( actual[1] );
        }

        [Fact]
        public void OrTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void OrTestNullCheck()
        {
            ISpecification<String> left = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.Or( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OrTestNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.Or( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}