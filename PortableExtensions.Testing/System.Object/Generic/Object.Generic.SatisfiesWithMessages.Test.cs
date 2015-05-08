#region Usings

using System;
using System.Linq;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void SatisfiesWithMessagesTestCase()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 )
                .And( x => x.StartsWith( "1" ) );

            var actual = "1234".SatisfiesWithMessages( specification )
                               .ToList();
            Assert.AreEqual( 0, actual.Count );
        }

        [Test]
        public void SatisfiesWithMessagesTestCase1()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3 )
                .And( x => x.StartsWith( "1" ) );

            var actual = "234".SatisfiesWithMessages( specification )
                              .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.IsNull( actual[0] );
            Assert.IsNull( actual[1] );
        }

        [Test]
        public void SatisfiesWithMessagesTestCase2()
        {
            var specification = new ExpressionSpecification<String>( x => x.Length > 3, "msg1" )
                .And( x => x.StartsWith( "1" ), "msg2" );

            var actual = "234".SatisfiesWithMessages( specification )
                              .ToList();
            Assert.AreEqual( 2, actual.Count );
            Assert.AreEqual( 1, actual.Count( x => x == "msg1" ) );
            Assert.AreEqual( 1, actual.Count( x => x == "msg2" ) );
        }

        [Test]
        [ExpectedException( typeof (ArgumentNullException) )]
        public void SatisfiesWithMessagesTestCasenullCheck()
        {
            ISpecification<String> specification = null;

            "1234".SatisfiesWithMessages( specification )
                  .ToList();
        }
    }
}