#region Using

using System;
using System.Collections.Generic;
using NUnit.Framework;

#endregion

namespace PortableExtensions.Testing
{
    [TestFixture]
    public partial class ObjectExTest
    {
        [TestCase]
        public void IsInTestCase()
        {
            var array = RandomValueEx.GetRandomStrings().ToArray();
            var value = array[0];

            var actual = value.IsIn( array );
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsIn( array );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsInTestCaseNullCheck()
        {
            String[] array = null;
            "".IsIn( array );
        }

        [TestCase]
        public void IsInTestCase1()
        {
            var list = RandomValueEx.GetRandomStrings();
            var value = list[0];

            var actual = value.IsIn( list );
            Assert.IsTrue( actual );

            value = RandomValueEx.GetRandomString();
            actual = value.IsIn( list );
            Assert.IsFalse( actual );
        }

        [TestCase]
        [ExpectedException( typeof ( ArgumentNullException ) )]
        public void IsInTestCase1NullCheck()
        {
            IEnumerable<String> enumerable = null;
            "".IsIn( enumerable );
        }
    }
}