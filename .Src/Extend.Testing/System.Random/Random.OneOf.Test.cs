#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class RandomExTest
    {
        [Test]
        public void RandomOneTest()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings()
                                    .ToArray();

            var actual = random.RandomOne( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [Test]
        public void RandomOneTest1()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings();

            var actual = random.RandomOne<String>( list );
            Assert.IsTrue( list.Contains( actual ) );
        }

        [Test]
        public void RandomOneTest1NullCheck()
        {
            Action test = () => RandomEx.RandomOne( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RandomOneTest1NullCheck1()
        {
            List<String> list = null;
            Action test = () => new Random().RandomOne<String>( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RandomOneTestNullCheck()
        {
            Action test = () => RandomEx.RandomOne( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void RandomOneTestNullCheck1()
        {
            String[] array = null;
            Action test = () => new Random().RandomOne( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}