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
        public void OrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTest10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTest11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void OrTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void OrTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void OrTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestNullCheck()
        {
            ISpecification<String> left = null;
            Action test = () => left.Or( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void OrTestNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            Action test = () => left.Or( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}