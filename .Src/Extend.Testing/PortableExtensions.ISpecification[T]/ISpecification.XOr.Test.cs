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
        public void XOrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.False( actual );
        }

        [Fact]
        public void XOrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.True( actual );
        }

        [Fact]
        public void XOrTest10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void XOrTest11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Equal( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.Equal( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Fact]
        public void XOrTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.True( actual );
        }

        [Fact]
        public void XOrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.False( actual );
        }

        [Fact]
        public void XOrTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actual );
            Assert.Equal( "The given object matches both specifications.", actual[0] );
        }

        [Fact]
        public void XOrTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void XOrTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void XOrTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actual.Count );
            Assert.Null( actual[0] );
            Assert.Null( actual[1] );
        }

        [Fact]
        public void XOrTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actual );
            Assert.Equal( "The given object matches both specifications.", actual[0] );
        }

        [Fact]
        public void XOrTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actual );
        }

        [Fact]
        public void XOrTestNullCheck()
        {
            ISpecification<String> left = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.XOr( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void XOrTestNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.XOr( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}