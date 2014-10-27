#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ISpecificationExTest
    {
        [Test]
        public void OrTestCase ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTestCase1 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTestCase10 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestCase11 ()
        {
            var left = new ExpressionSpecification<String>( x => false, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.AreEqual( 1, actual.Count( x => x == "msgLeft" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msgRight" ) );
        }

        [Test]
        public void OrTestCase2 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsTrue( actual );
        }

        [Test]
        public void OrTestCase3 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedBy( String.Empty );
            Assert.IsFalse( actual );
        }

        [Test]
        public void OrTestCase4 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestCase5 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestCase6 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => true );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestCase7 ()
        {
            var left = new ExpressionSpecification<String>( x => false );
            var target = left.Or( x => false );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 2, actual.Count() );
            Assert.IsNull( actual [0] );
            Assert.IsNull( actual [1] );
        }

        [Test]
        public void OrTestCase8 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => true, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty );
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        public void OrTestCase9 ()
        {
            var left = new ExpressionSpecification<String>( x => true, "msgLeft" );
            var target = left.Or( x => false, "msgRight" );

            var actual = target.IsSatisfiedByWithMessages( String.Empty ).ToList();
            Assert.AreEqual( 0, actual.Count() );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void OrTestCaseNullCheck ()
        {
            ISpecification<String> left = null;
            left.Or( x => true );
        }

        [Test]
        [ExpectedException ( typeof (ArgumentNullException) )]
        public void OrTestCaseNullCheck1 ()
        {
            var left = new ExpressionSpecification<String>( x => true );
            Func<String, Boolean> expression = null;
            left.Or( expression );
        }
    }
}