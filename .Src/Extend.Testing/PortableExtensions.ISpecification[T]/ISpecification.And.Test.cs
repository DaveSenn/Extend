#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ISpecificationExTest
    {
        [Test]
        public void AndTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            actual.Should()
                  .BeTrue();
        }

        [Test]
        public void AndTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            actual.Should()
                  .BeFalse();
        }

        [Test]
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

        [Test]
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

        [Test]
        public void AndTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void AndTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void AndTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void AndTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count() );
            Assert.IsNull( actual[0] );
        }

        [Test]
        public void AndTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count() );
            Assert.IsNull( actual[0] );
        }

        [Test]
        public void AndTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.And( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void AndTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.And( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void AndTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.And( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count() );
            Assert.AreEqual( "msgRight", actual[0] );
        }

        [Test]
        public void AndTestNullCheck()
        {
            ISpecification<String> left = null;
            Action test = () => left.And( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void AndTestNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            Action test = () => left.And( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}