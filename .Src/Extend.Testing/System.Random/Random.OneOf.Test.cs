#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class RandomExTest
    {
        [Fact]
        public void RandomOneTest()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings()
                                    .ToArray();

            var actual = random.RandomOne( list );
            Assert.Contains( actual, list );
        }

        [Fact]
        public void RandomOneTest1()
        {
            var random = new Random();
            var list = RandomValueEx.GetRandomStrings();

            var actual = random.RandomOne<String>( list );
            Assert.Contains( actual, list );
        }

        [Fact]
        public void RandomOneTest1NullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomEx.RandomOne( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RandomOneTest1NullCheck1()
        {
            List<String> list = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Random().RandomOne<String>( list );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RandomOneTestNullCheck()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => RandomEx.RandomOne( null, "", "" );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RandomOneTestNullCheck1()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => new Random().RandomOne( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}