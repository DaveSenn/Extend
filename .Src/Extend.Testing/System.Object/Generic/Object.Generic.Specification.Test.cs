#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void SpecificationTestCase()
        {
            var target = 11;
            var actual = target.Specification( x => x > 10 && x < 200 );

            var result = actual.IsSatisfiedBy( target );
            Assert.IsTrue( result );

            target = 200;
            result = actual.IsSatisfiedBy( target );
            Assert.IsFalse( result );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SpecificationTestCaseNullCheck()
        {
            const Int32 target = 11;
            Func<Int32, Boolean> expression = null;
            target.Specification( expression );
        }
    }
}