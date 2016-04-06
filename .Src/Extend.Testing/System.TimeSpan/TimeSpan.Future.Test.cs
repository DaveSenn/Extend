#region Usings

using System;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class TimeSpanExTest
    {
        [Test]
        public void FutureTest()
        {
            var expected = DateTime.Now.Add( TimeSpan.FromDays( 1 ) );
            var actual = TimeSpan.FromDays( 1 )
                                 .Future();

            Assert.AreEqual( expected.Day, actual.Day );
        }
    }
}