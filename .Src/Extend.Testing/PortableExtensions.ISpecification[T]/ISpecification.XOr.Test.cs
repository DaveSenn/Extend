#region Usings

using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public partial class ISpecificationExTest
    {
        [Test]
        public void XOrTest()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void XOrTest1()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void XOrTest10()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void XOrTest11()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void XOrTest2()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void XOrTest3()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void XOrTest4()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "The given object matches both specifications.", actual[0] );
        }

        [Test]
        public void XOrTest5()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void XOrTest6()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void XOrTest7()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.XOr( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void XOrTest8()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 1, actual.Count );
            Assert.AreEqual( "The given object matches both specifications.", actual[0] );
        }

        [Test]
        public void XOrTest9()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.XOr( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void XOrTestNullCheck()
        {
            ISpecification<String> left = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            Action test = () => left.XOr( x => true );
            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
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