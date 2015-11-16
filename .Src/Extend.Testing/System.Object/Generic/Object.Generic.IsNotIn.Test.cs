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
        public void IsNotInTestCase()
        {
            var array = RandomValueEx.GetRandomStrings()
                                     .ToArray();
            var value = array[0];

            var actual = value.IsNotIn( array );
            Assert.IsFalse( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsNotIn( array );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotInTestCase1()
        {
            var list = RandomValueEx.GetRandomStrings();
            var value = list[0];

            var actual = value.IsNotIn( list );
            Assert.IsFalse( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsNotIn( list );
            Assert.IsTrue( actual );
        }

        [Test]
        public void IsNotInTestCase1NullCheck()
        {
            IEnumerable<String> enumerable = null;
            Action test = () => "".IsNotIn( enumerable );

            test.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void IsNotInTestCaseNullCheck()
        {
            String[] array = null;
            Action test = () => "".IsNotIn( array );

            test.ShouldThrow<ArgumentNullException>();
        }
    }
}