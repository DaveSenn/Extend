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
        public void XOrTestCase()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void XOrTestCase1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void XOrTestCase10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void XOrTestCase11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void XOrTestCase2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void XOrTestCase3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void XOrTestCase4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "The given object matches both specifications.", actual[0] );
        }

        [Test]
        public void XOrTestCase5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void XOrTestCase6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void XOrTestCase7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void XOrTestCase8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "The given object matches both specifications.", actual[0] );
        }

        [Test]
        public void XOrTestCase9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void XOrTestCaseNullCheck()
        {
            ISpecification<String> left = null;
            Action test = () => left.XOr( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void XOrTestCaseNullCheck1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            Action test = () => left.XOr( expression );
            test.ShouldThrow<ArgumentNullException>();
        }
    }
}