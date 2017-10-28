#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

#endregion

namespace Extend.Testing
{
    public partial class ObjectExTest
    {
        [Fact]
        public void IsNotInTest()
        {
            var array = RandomValueEx.GetRandomStrings()
                                     .ToArray();
            var value = array[0];

            var actual = value.IsNotIn( array );
            Assert.False( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsNotIn( array );
            Assert.True( actual );
        }

        [Fact]
        public void IsNotInTest1()
        {
            var list = RandomValueEx.GetRandomStrings();
            var value = list[0];

            var actual = value.IsNotIn( list );
            Assert.False( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsNotIn( list );
            Assert.True( actual );
        }

        [Fact]
        public void IsNotInTest1NullCheck()
        {
            IEnumerable<String> enumerable = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsNotIn( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void IsNotInTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsNotIn( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}