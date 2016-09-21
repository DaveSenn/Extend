#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

#endregion

namespace Extend.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [Test]
        public void IsInTest()
        {
            var array = RandomValueEx.GetRandomStrings()
                                     .ToArray();
            var value = array[0];

            var actual = value.IsIn( array );
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsIn( array );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsInTest1()
        {
            var list = RandomValueEx.GetRandomStrings();
            var value = list[0];

            var actual = value.IsIn( list );
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsIn( list );
            Assert.IsFalse( actual );
        }

        [Test]
        public void IsInTest1NullCheck()
        {
            IEnumerable<String> enumerable = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsIn( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsInTestNullCheck()
        {
            String[] array = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Action test = () => "".IsIn( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}