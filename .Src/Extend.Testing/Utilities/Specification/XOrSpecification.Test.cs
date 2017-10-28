#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public class XOrSpecificationTest
    {
        [Fact]
        public void AndTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTest2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void AndTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTest4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.And( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void AndTestNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

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
            Action test = () => new XOrSpecification<String>( new ExpressionSpecification<String>( x => true ), null );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CtorTestNulLCheck1()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ObjectCreationAsStatement
            Action test = () => new XOrSpecification<String>( null, new ExpressionSpecification<String>( x => true ) );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsSatisfiedByTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.False( actaul );
        }

        [Fact]
        public void IsSatisfiedByTest1()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.True( actaul );
        }

        [Fact]
        public void IsSatisfiedByTest2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.True( actaul );
        }

        [Fact]
        public void IsSatisfiedByTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedBy( String.Empty );
            Assert.False( actaul );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actaul );
            Assert.Equal( "The given object matches both specifications.", actaul[0] );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest1()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => true );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actaul );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actaul );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actaul.Count );
            Assert.Null( actaul[0] );
            Assert.Null( actaul[1] );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest4()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Single( actaul );
            Assert.Equal( "The given object matches both specifications.", actaul[0] );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest5()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => true, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actaul );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest6()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Empty( actaul );
        }

        [Fact]
        public void IsSatisfiedByWithMessagesTest7()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var right = new ExpressionSpecification<String>( x => false, "msgRight" );

            var target = new XOrSpecification<String>( left, right );
            var actaul = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.Equal( 2, actaul.Count );
            Assert.Equal( 1, actaul.Count( x => x == "msgLeft" ) );
            Assert.Equal( 1, actaul.Count( x => x == "msgRight" ) );
        }

        [Fact]
        public void OrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void OrTest2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void OrTest4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.Or( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void OrTestNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.Or( other );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void XOrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void XOrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => true );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void XOrTest2()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void XOrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => true ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.True( result );
        }

        [Fact]
        public void XOrTest4()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            var actual = target.XOr( new ExpressionSpecification<String>( x => false ) );
            var result = actual.IsSatisfiedBy( String.Empty );
            Assert.False( result );
        }

        [Fact]
        public void XOrTestNullCheck()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var right = new ExpressionSpecification<String>( x => false );
            var target = new XOrSpecification<String>( left, right );

            ExpressionSpecification<String> other = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => target.XOr( other );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}